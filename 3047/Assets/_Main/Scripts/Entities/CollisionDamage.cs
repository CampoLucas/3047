using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    //The purpose of this script is to inflict damage when a ship, asteroid, bullet or any other entity that inflict damage when it collides
    //When the player ship collides with a enemy ship both ships should take damage.
    //When the player collides with an asteroid the player should take damage and the asteroid should divide itself into 2 or 3 depending its size and should be destroyed (Maybe)
    //Enemies, bosses and asteroids or other projectiles cannot collide between them, just with the player.

    [SerializeField] private StatsSO _stats;

    private void Awake()
    {
        if (!_stats)
            _stats = GetComponent<Entity>().Data;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ship ship = other.GetComponent<Ship>();
        if (!other.gameObject.CompareTag(this.tag) && ship)
            ship.TakeDamage(_stats.Damage);
    }
   
}
