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
        ai.ID = 001;
        ai.CurrentHitpoints = 100;
        ai.MaximumHitpoints = 100;
        ai.Damage = 10;
        ai.Aggressiveness = 5;
        ai.AttackRange = 5;
        ai.WanderTime = 5;
        ai.WanderRadius = 5;
        ai.Name = "enemy";
        ai.CanAttack = true;

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

        var decisionWeight = 0;

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

        if( decision != null ) decision.Run( ai );
    }

    void Update()
    {
        transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z);
    }
}
