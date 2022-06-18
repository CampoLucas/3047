using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int HP_To_Heal;
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
                player.Damageable.AddLife(HP_To_Heal);
                Destroy(gameObject);
            }
        }
    }
}
