using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : PickUP
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameCompleted();
        }
    }
}
