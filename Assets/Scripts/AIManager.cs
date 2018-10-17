using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    private static AIManager _instance;

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
        GameObject g = GameObject.FindWithTag("AI");

        allAI.Add(g);

        //call every 3 frames
        InvokeRepeating("UpdateAI", 0f, 180f);

        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
    }

    void UpdateAI()
    {
        //for every AI
        print("Number of ais in ai manager is " + allAI.Count);
        foreach (var ai in allAI)
        {
            print("Trying to find settings on " + ai.name);
            var settings = ai.GetComponent<AI>();
            if (settings == null) print("Couldn't find settings on ai game object!");

            if (!settings.CanPerformAction)
                continue;

            Debug.Log("AI for action");

            var decisionRank = 0;

            var decisionWeight = 0;

            BaseAction decision = null;

            foreach (var action in settings.actions)
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

                    decision = action;

                    Debug.Log("made decision");
                }
            }

            //var aiAction = ai.AddComponent(typeof(BaseAction));
            if( decision != null ) decision.Run( ai );
            Debug.Log("made action");
        }
    }
}
