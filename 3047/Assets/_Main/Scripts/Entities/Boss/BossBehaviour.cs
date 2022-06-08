using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private Boss _boss;
    private void Awake()
    {
        _boss = GetComponent<Boss>();
    }

    private void Update()
    {
        if(_boss.state == BossState.Phase1)
        {

        }
        else if(_boss.state == BossState.Phase2)
        {

        }
        else
        {

        }


    }
}

