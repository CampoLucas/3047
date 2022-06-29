using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PowerUp : PickUP
{
    [SerializeField] private Weapon PowerUpWeapon;
    [SerializeField] private float _coolDown = 10f;

    
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                player.PowerUp(PowerUpWeapon,_coolDown);
                Destroy(gameObject);
            }
        }
    }
}
