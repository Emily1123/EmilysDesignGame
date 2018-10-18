using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{

    public Transform target;
    public float thinkRate;

    public NavMeshAgent agent;
    public Animator anim;
    public AI ai;

    void Start()
    {
        GameObject g = GameObject.FindWithTag("AI");

        StartCoroutine( RepeatAI() );
    }

    IEnumerator RepeatAI() {
        while( enabled ) {
            UpdateAI();

            yield return new WaitForSeconds( thinkRate );
        }
    }

    void UpdateAI()
    {
        if (ai == null) print("Couldn't find settings on ai game object!");

        var decisionRank = -1; // TODO: Set back to zero once we have some factors to work with

        var decisionWeight = -1;

        BaseAction decision = null;

        foreach (var action in ai.actions)
        {
            var curActionRank = action.GetRank(ai);

            var curActionWeight = action.GetWeight(ai);

            if (curActionRank >= decisionRank && curActionWeight > decisionWeight)
            {
                decisionRank = curActionRank;

                decisionWeight = curActionWeight;

                decision = action;
            }
        }

        //var aiAction = ai.AddComponent(typeof(BaseAction));
        if( decision != null ) decision.Run( ai );
    }

    void Update()
    {
        transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z);
    }
}
