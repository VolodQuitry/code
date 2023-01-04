using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Resource
{
    [SerializeField] private int _damage;

    protected override void SetPlayer(Player player)
    {
        player.TakeDamage(_damage);
    }
}
