using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleAction : BaseAction
{
    //public List<BaseFactor> Factors;

    override public int GetRank(GameObject aiToCheck)
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

    override public int GetWeight(GameObject aiToCheck)
    {
        //sum of bonuses * product of multipliers
        var weight = 0;

        foreach (var factor in Factors)
        {
            weight += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
        }

        return weight;
    }

    override public void Run(GameObject ai)
    {
        var mySettings = ai.GetComponent<AI>();

        mySettings.CanPerformAction = false;

        float wanderRadius = GetComponent<AI>().WanderRadius;

        int wanderTimer = GetComponent<AI>().WanderTime;

        int seconds = 0;

        seconds = wanderTimer;

        StartCoroutine(TimeBetweenDest(seconds));

        while (seconds > wanderTimer)
        {
            if (seconds != 0)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);

                AIManager aiManager = ai.GetComponent<AIManager>();

                aiManager.agent.destination = newPos;
            }
        }

        mySettings.CanPerformAction = true;

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
