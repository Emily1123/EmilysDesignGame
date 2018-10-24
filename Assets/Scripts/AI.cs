using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    private int _id;
    public int ID
    {
        get { return _id; }
        set
        {
            _id = value;
        }
    }

    [SerializeField]
    private float _currentHitpoints;
    public float CurrentHitpoints
    {
        get { return _currentHitpoints; }
        set
        {
            _currentHitpoints = value;
        }
    }

    [SerializeField]
    private float _maximumHitpoints;
    public float MaximumHitpoints
    {
        get { return _maximumHitpoints; }
        set
        {
            _maximumHitpoints = value;
        }
    }

    [SerializeField]
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        set
        {
            _damage = value;
        }
    }

    [SerializeField]
    private float _aggressiveness;
    public float Aggressiveness
    {
        get { return _aggressiveness; }
        set
        {
            _aggressiveness = value;
        }
    }

    [SerializeField]
    private int _wanderTime;
    public int WanderTime
    {
        get { return _wanderTime; }
        set
        {
            _wanderTime = value;
        }
    }

    [SerializeField]
    private float _wanderRadius;
    public float WanderRadius
    {
        get { return _wanderRadius; }
        set
        {
            _wanderRadius = value;
        }
    }

    [SerializeField]
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }

    [SerializeField]
    private bool _canAttack;
    public bool CanAttack
    {
        get { return _canAttack; }
        set
        {
            _canAttack = value;
        }
    }

    [SerializeField]
    private ItemDrop _droppedItem;
    public ItemDrop DroppedItem
    {
        get { return _droppedItem; }
        set
        {
            _droppedItem = value;
        }
    }

    public AIManager aiManager;

    public List<BaseAction> actions = new List<BaseAction>();
}
