using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int ID { get; set; }

    public int CurrentHitpoints { get; set; }

    public int MaximumHitpoints { get; set; }

    public int Damage { get; set; }

    public int Aggressiveness { get; set; }

    public int AttackRange { get; set; }

    public int WanderTime { get; set; }

    public float WanderRadius { get; set; }

    public string Name { get; set; }

    public bool CanAttack { get; set; }

    public bool CanPerformAction { get; set; }

    public Item DroppedItem { get; set; }

    public Item DropItem()
    {
        return DroppedItem;
    }
}
