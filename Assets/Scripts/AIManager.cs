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
        StartCoroutine( RepeatAI() );
    }

    IEnumerator RepeatAI() {
        while( enabled )
        {
            UpdateAI();

            yield return new WaitForSeconds( thinkRate );
        }
    }

    void UpdateAI()
    {
        if (ai == null) print("Couldn't find settings on ai game object!");

        var decisionRank = 0;

        // var decisionWeight = 0;

        BaseAction decision = null;

        foreach (var action in ai.actions)
        {
            var curActionRank = action.GetRank(ai);

            // var curActionWeight = action.GetWeight(ai);

            if (curActionRank >= decisionRank /* || curActionWeight > decisionWeight */)
            {
                decisionRank = curActionRank;

                // decisionWeight = curActionWeight;

                decision = action;
            }
        }

        if( decision != null ) decision.Run( ai );
    }

    void Update()
    {
        transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z);
        float relX = agent.destination.x - transform.position.x;
        if( relX < 0f ) {
            transform.right = Vector3.right;
        }
        else {
            transform.right = -Vector3.right;
        }
    }
}
