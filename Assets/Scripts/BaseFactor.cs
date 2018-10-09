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
        return 0;
    }

    virtual public int GetFactorBonus(GameObject aiToCheck)
    {
        //default bonus is 0
        return 0;
    }

    virtual public int GetFactorMultiplier(GameObject aiToCheck)
    {
        //default multiplier is 0
        return 1;
    }
}
