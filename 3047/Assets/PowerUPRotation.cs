using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
