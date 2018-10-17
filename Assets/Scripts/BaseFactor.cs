using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public class BaseFactor : MonoBehaviour
{

    virtual public int GetFactorRank(GameObject aiToCheck)
    {
        //default rank is 0
        Debug.Log("got factor rank");

        return 0;
    }

    virtual public int GetFactorBonus(GameObject aiToCheck)
    {
        //default bonus is 0
        Debug.Log("got factor bonus");

        return 0;
    }

    virtual public int GetFactorMultiplier(GameObject aiToCheck)
    {
        //default multiplier is 0
        Debug.Log("got factor multiplier");

        return 1;
    }
}
