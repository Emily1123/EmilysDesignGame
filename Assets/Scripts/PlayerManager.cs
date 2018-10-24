using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float _startingHP;
    public float StartingHP
    {
        get { return _startingHP; }
        set
        {
            _startingHP = value;
        }
    }

    [SerializeField]
    private float _currentHP;
    public float CurrentHP
    {
        get { return _currentHP; }
        set
        {
            _currentHP = value;
        }
    }

    [SerializeField]
    private float _minAttack;
    public float MinAttack
    {
        get { return _minAttack; }
        set
        {
            _minAttack = value;
        }
    }

    [SerializeField]
    private float _maxAttack;
    public float MaxAttack
    {
        get { return _maxAttack; }
        set
        {
            _maxAttack = value;
        }
    }

    [SerializeField]
    private float _amountDamage;
    public float AmountDamage
    {
        get { return _amountDamage; }
        set
        {
            _amountDamage = value;
        }
    }

    [SerializeField]
    private bool _youDead;
    public bool YouDead
    {
        get { return _youDead; }
        set
        {
            _youDead = value;
        }
    }

    public GameObject player;

    public PlayerMove playerMovement;

    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
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
