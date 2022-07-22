using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private IMovable _movable;
    private void Awake()
    {
        _movable = GetComponent<IMovable>();
    }
    protected virtual void Update()
    {
        _movable.Move(transform.right);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {

    }
}
