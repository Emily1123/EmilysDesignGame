using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDesireFactor : BaseFactor
{
    public AI ai;

    public PlayerManager player;

    //AI health
    float hp;

    //AI agressiveness
    float aggressiveness;

    //min and max damage the player can dish out
    float minDamage;

    float maxDamage;

    //player health
    float playerHp;

    override public int GetFactorRank(AI aiToCheck)
    {
        hp = ai.CurrentHitpoints;

        aggressiveness = ai.Aggressiveness;

        minDamage = player.MinAttack;

        maxDamage = player.MinAttack;

        playerHp = player.CurrentHP;

        //range-bound linear attack-desire curve
        float inverseRatio = 1 - ((float)(playerHp - minDamage) / (maxDamage - minDamage));

        float calcNum = (inverseRatio * (1 - aggressiveness)) + aggressiveness;

        float score = Math.Max(Math.Min(calcNum, 1), aggressiveness);

        if (score > 0.8)
        {
            return 15;
        }

        if (score > 0.6)
        {
            return 10;
        }

        else
        {
            return 5;
        }
    }

    override public int GetFactorBonus(AI aiToCheck)
    {
        //if player is low health, give higher weight
        if (playerHp < 20)
        {
            return 10;
        }

        return 1;
    }

    override public int GetFactorMultiplier(AI aiToCheck)
    {
        //if AI health is low, set weight to 0
        if (hp < 10)
        {
            return 0;
        }

        return 1;
    }
}

