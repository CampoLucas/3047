using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour//TODO finish this
{
    [Header("Enemy Groups prefabs")]
    public List<GameObject> enemyGroups;
    public float[] timesToSpawn;
    private int i = 0;
    private void Awake()
    {
         i = 0;
    }

    private void Update()
    {
        if (i<timesToSpawn.Length)
        {
            if (GameManager.instance.currentGameTime >= timesToSpawn[i])
            {
                SpawnGroup(i);
                i++;
            }
        }
    }

    private void SpawnGroup(int index)
    {
        if (index>=enemyGroups.Count) return;
        Instantiate(enemyGroups[index],transform.position,Quaternion.identity);
    }

}
