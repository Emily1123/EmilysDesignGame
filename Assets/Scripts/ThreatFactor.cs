using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatFactor : BaseFactor
{
    public AI ai;

    //AI health
    float hp;

    //max damage the player can dish out
    float maxDamage;

    override public int GetFactorRank(AI aiToCheck)
    {
        if (ai != null)
        {
            hp = GetComponent<AI>().CurrentHitpoints;

            maxDamage = GetComponent<PlayerManager>().MaxAttack;
        }
        else
        {
            print("No AI found on MyObject for threat factor!");
        }
        
        //determine what percentage of AI’s current hit points will be taken away if the player hits for maximum damage
        float score = Math.Min((maxDamage / hp), 1);

        if (score > 0.8)
        {
            return 15;
        }

        if (score > 0.4)
        {
            return 10;
        }

        if (score > 0.2)
        {
            return 5;
        }

        return 0;
    }

    override public int GetFactorBonus(AI aiToCheck)
    {
        return 1;
    }

    override public int GetFactorMultiplier(AI aiToCheck)
    {
        //if AI health is low, give higher weight
        if (hp < 10)
        {
            return 2;
        }

        return 1;
    }
}

