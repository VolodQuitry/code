using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Resource
{
    [SerializeField] private float _stunDelay;

    protected override void SetPlayer(Player player)
    {
        player.Stun(_stunDelay);
    }
}
