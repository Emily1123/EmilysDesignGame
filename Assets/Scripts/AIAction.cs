using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAction : MonoBehaviour
{
    public enum Factors { None, Distance, Threat, AttackDesire};
    Factors currentDecision;
    public void ActionToPerform()
    {
        currentDecision = Factors.None;
    }

    public void Run()
    {

    }
}
