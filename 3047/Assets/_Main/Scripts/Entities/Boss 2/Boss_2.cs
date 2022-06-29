using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : Ship
{

    [SerializeField] private GameObject Boss_2_object;
    public override void OnDieListener()
    {
        Boss_2_object.SetActive(false);
        GameManager.instance.GameCompleted();
        base.OnDieListener();
    }
}
