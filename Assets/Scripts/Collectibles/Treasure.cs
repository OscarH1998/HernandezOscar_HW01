using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int _increaseTreasure = 1;

    protected override void Collect(Player player)
    {
        player.IncreaseTreasure(_increaseTreasure);
    }

    protected override void Movement(Rigidbody rb)
    {
        //calculate rotation
        Quaternion turnOffset = Quaternion.Euler(0, MovementSpeed, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
