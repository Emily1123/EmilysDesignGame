using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAction : MonoBehaviour
{
    public int BaseWeight;

    public float SecondsToCacheRank = 10f;

    private int _weightBonus;

    private int _rank;

    private float _nextChacheTime;

    //Factors to consider for this action
    public List<BaseFactor> Factors;

    virtual public int GetRank(AI aiToCheck)
    {
        if (_rank > 0 && _nextChacheTime > Time.timeSinceLevelLoad)
        {
            return _rank;
        }
        _nextChacheTime = Time.timeSinceLevelLoad + SecondsToCacheRank;

        _rank = 0;

        foreach (var factor in Factors)
        {
            if (factor.GetFactorRank(aiToCheck) > _rank)
            {
                _rank += factor.GetFactorRank(aiToCheck);
            }
        }

        Debug.Log("got final rank");

        return _rank;
    }

    // virtual public int GetWeight(AI aiToCheck)
    // {
    //     //sum of bonuses * product of multipliers
    //     _weightBonus = 0;

    //     foreach (var factor in Factors)
    //     {
    //         _weightBonus += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
    //     }

    //     Debug.Log("got final weight");

    //     return _weightBonus;
    // }

    virtual public void Run(AI ai) { }
}
