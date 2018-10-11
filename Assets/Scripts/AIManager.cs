using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    private static AIManager _instance;

    public List<BaseAction> Actions;

    public List<GameObject> allAI = new List<GameObject>();

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
        GameObject g = GameObject.Find("AI");

        allAI.Add(g);

        //call every 3 frames
        InvokeRepeating("UpdateAI", 0f, 180f);

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

            Debug.Log("AI for action");

            var decisionRank = 0;

            var decisionWeight = 0;

            AIAction decision;

            foreach (var action in Actions)
            {
                var curActionRank = action.GetRank(ai);

                var curActionWeight = action.GetWeight(ai);

                if (curActionWeight <= 0)
                    continue;

                Debug.Log("selecting action");

                if (curActionRank > decisionRank || curActionRank == decisionRank && curActionWeight > decisionWeight)
                {
                    decisionRank = curActionRank;

                    decisionWeight = curActionWeight;

                    decision = action.ActionToPerform;

                    Debug.Log("made decision");
                }
            }

            var aiAction = ai.AddComponent(typeof(AIAction));
            //aiAction.Run();
            Debug.Log("made action");
        }
    }
}
