using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    public GameObject player;

    Vector3 _pushLine;

    void Update()
    {
        _pushLine = new Vector3(transform.position.x-1, 1, transform.position.z-1);
    }

    protected override void PlayerImpact(Player player)
    {
        player.transform.position = _pushLine - transform.position;
    }
}
