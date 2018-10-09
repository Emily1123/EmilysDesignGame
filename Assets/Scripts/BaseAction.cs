using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public class BaseAction : MonoBehaviour
{
    public int BaseWeight;

    public float SecondsToCacheRank = 10f;

    private int _weightBonus;

    private int _rank;

    private float _nextChacheTime;

    //Factors to consider for this action
    public List<BaseFactor> Factors;

    //Action that will be performed if this is picked
    public AIAction ActionToPerform;

    virtual public int GetRank(GameObject aiToCheck)
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

        return _rank;
    }

    virtual public int GetWeight(GameObject aiToCheck)
    {
        //sum of bonuses * product of multipliers
        _weightBonus = 0;

        foreach (var factor in Factors)
        {
            _weightBonus += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
        }
        return _weightBonus;
    }

    virtual public void Run(GameObject ai) { }
}
