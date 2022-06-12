using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    //This script spawns a gameobject at a specific time ---- 
    //enemygroups[0] will spawn at the time: timesToSpawn[0]
    //eg. enemygroup[0] => prefab TargetShotStraight will spawn after timesToSpawn[0]=>30f which is 30seconds
    //in the inspector Element0 of enemyGroups will spawn after Element0 of timesToSpawn in seconds
    //elements must be in order to work properly and be legible
    [SerializeField]private int _index = 0;
    public List<GameObject> enemyGroups;
    public float[] timesToSpawn;
    private void Start()
    {
         _index = 0;
         GameManager.instance.OnLevelReset.AddListener(ResetSpawner);
    }
    
    private void Update()
    {
        if (_index<timesToSpawn.Length)
        {
            if (GameManager.instance.currentGameTime >= timesToSpawn[_index])
            {
                SpawnGroup(_index);
                _index++;
            }
        }
    }

    private void SpawnGroup(int index)
    {
        if (enemyGroups.Count==0) return;
        if (index>=enemyGroups.Count) return;
        Instantiate(enemyGroups[index],transform.position,Quaternion.identity);
    }

    private void ResetSpawner()
    {
        _index = 0;
    }
}
