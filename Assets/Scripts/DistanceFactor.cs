using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFactor : BaseFactor
{
    //max distance AI's attack can reach
    float attackRange;

    override public int GetFactorRank(GameObject aiToCheck)
    {
        attackRange = GetComponent<AI>().AttackRange;

        RaycastHit hit;

        //if AI sees player, it has a lower probability of searching for player
        if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                return 5;
            }
        }

        return 20;
    }

    override public int GetFactorBonus(GameObject aiToCheck)
    {
        return 1;
    }

    override public int GetFactorMultiplier(GameObject aiToCheck)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //if player is within attack range, set weight to 0
        if (attackRange <= Vector3.Distance(aiToCheck.transform.position, player.transform.position))
        {
            return 0;
        }

        return 1;
    }
}

