using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleAction : BaseAction
{
    override public int GetRank(AI aiToCheck)
    {
        var rank = 0;

        foreach (var factor in Factors)
        {
            if (factor.GetFactorRank(aiToCheck) > rank)
            {
                rank += factor.GetFactorRank(aiToCheck);
            }
        }

        return rank;
    }

    // override public int GetWeight(AI aiToCheck)
    // {
    //     //sum of bonuses * product of multipliers
    //     var weight = 0;

    //     foreach (var factor in Factors)
    //     {
    //         weight += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
    //     }

    //     return weight;
    // }

    override public void Run(AI ai)
    {
        float wanderRadius = ai.WanderRadius;

        int wanderTimer = ai.WanderTime;

        int seconds = 0;

        seconds = wanderTimer;

        StartCoroutine(TimeBetweenDest(seconds));

        while (seconds > wanderTimer)
        {
            if (seconds != 0)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);

                ai.aiManager.agent.destination = newPos;
            }
        }

        //Remove this script from its parent
        Destroy(this);
    }

    IEnumerator TimeBetweenDest(int seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
