using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickUP
{
    [SerializeField] private int HP_To_Heal;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                player.Damageable.AddLife(HP_To_Heal);
                Destroy(gameObject);
            }
        }
    }
}
