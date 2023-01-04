using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Resource
{
    [SerializeField] private int _health;

    protected override void SetPlayer(Player player)
    {
        player.AddHealth(_health);
    }
}
