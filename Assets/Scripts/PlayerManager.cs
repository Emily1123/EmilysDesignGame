using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int StartingHP { get; set; }

    public int CurrentHP { get; set; }

    public int MinAttack { get; set; }

    public int MaxAttack { get; set; }

    public int AmountDamage { get; set; }

    public bool YouDead { get; set; }

    public GameObject player;

    public PlayerMove playerMovement;

    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject { name = typeof(PlayerManager).Name };

                    _instance = go.AddComponent<PlayerManager>();

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
        player = GameObject.FindGameObjectWithTag("Player");

        playerMovement = GetComponent<PlayerMove>();

        CurrentHP = StartingHP;
    }

     void Update()
    {
        if (CurrentHP <= 0 && !YouDead)
        {
            Death();
        }
    }

    void Death()
    {
        YouDead = true;

        //playerMovement.enabled = false;
    }
}
