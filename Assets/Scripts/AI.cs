using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int ID { get; set; }

    public float CurrentHitpoints { get; set; }

    public float MaximumHitpoints { get; set; }

    public float Damage { get; set; }

    public float Aggressiveness { get; set; }

    public float AttackRange { get; set; }

    public int WanderTime { get; set; }

    public float WanderRadius { get; set; }

    public string Name { get; set; }

    public bool CanAttack { get; set; }

    public ItemDrop DroppedItem { get; set; }

    public AIManager aiManager;

    public ItemDrop DropItem()
    {
        return DroppedItem;
    }

    public List<BaseAction> actions = new List<BaseAction>();
}
