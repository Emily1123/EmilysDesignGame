using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    private static AIManager _instance;

    public List<BaseAction> Actions;

    public GameObject[] allAI;

    public NavMeshAgent agent;

    public Animator anim;

    public static AIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AIManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject{name = typeof(AIManager).Name};

                    _instance = go.AddComponent<AIManager>();

                    DontDestroyOnLoad(go);
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //call every 3 frames
        InvokeRepeating("Update", 0f, 180f);

        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
    }

    void UpdateAI()
    {
        //for every AI
        foreach (var ai in allAI)
        {
            var settings = ai.GetComponent<AI>();

            if (!settings.CanPerformAction)
                continue;

            var decisionRank = 0;

            var decisionWeight = 0;

            AIAction decision;

            foreach (var action in Actions)
            {
                var curActionRank = action.GetRank(ai);

                var curActionWeight = action.GetWeight(ai);

                if (curActionWeight <= 0)
                    continue;

                if (curActionRank > decisionRank || curActionRank == decisionRank && curActionWeight > decisionWeight)
                {
                    decisionRank = curActionRank;

                    decisionWeight = curActionWeight;

                    decision = action.ActionToPerform;
                }
            }

            //var aiAction = ai.AddComponent(typeof(decision));

            //aiAction.Run(GameObject ai);
        }
    }
}
