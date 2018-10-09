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
            weight+= factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
        }

        return weight;
    }

    override public void Run(GameObject ai)
    {
        var mySettings = ai.GetComponent<AI>();

        mySettings.CanPerformAction = false;

        float wanderRadius = 0;

        float wanderTimer = 0;

        float timer = 0;

        timer = wanderTimer;

        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);

            AIManager aiManager = ai.GetComponent<AIManager>();

            aiManager.agent.destination = newPos;

            timer = 0;
        }

        mySettings.CanPerformAction = true;

        //Remove this script from its parent
        Destroy(this);
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
