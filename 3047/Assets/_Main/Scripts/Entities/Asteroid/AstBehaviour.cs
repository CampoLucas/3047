using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstBehaviour : MonoBehaviour
{
    [Header("Components")]
    private Asteroid _asteroid;
    void Awake()
    {
        _asteroid = GetComponent<Asteroid>();
    }

    // Update is called once per frame
    void Update()
    {
        _asteroid.Move((_asteroid.MoveDirection).normalized);
    }
}
