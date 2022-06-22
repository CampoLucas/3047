using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private Weapon PowerUpWeapon;
    [SerializeField] private float _coolDown = 10f;
    [SerializeField] private float _rotationSpeed = 20f;
    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
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
