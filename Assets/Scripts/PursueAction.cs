using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueAction : BaseAction
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

    override public int GetWeight(AI aiToCheck)
    {
        //sum of bonuses * product of multipliers
        var weight = 0;

        foreach (var factor in Factors)
        {
            weight += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
        }

        return weight;
    }

    override public void Run(AI ai)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        ai.aiManager.agent.destination = player.transform.position;
    }
}
