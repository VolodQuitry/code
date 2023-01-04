using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Resource
{
    [SerializeField] private int _coin;

    protected override void SetPlayer(Player player)
    {
        player.AddCoin(_coin);
    }
}
