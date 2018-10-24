using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : BaseAction
{
    override public int GetRank(AI aiToCheck)
    {
        var rank = 0;

        foreach (var factor in Factors)
        {
            int factorRank = factor.GetFactorRank(aiToCheck);
            if( factor.abort ) return 0;

            if (factorRank > rank)
            {
                rank += factorRank;
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
        ai.aiManager.anim.SetTrigger( "attackTrigger" );
        PlayerManager.Instance.CurrentHP -= ai.Damage;
    }
}
