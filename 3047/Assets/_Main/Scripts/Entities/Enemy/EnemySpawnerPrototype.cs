using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPrototype : MonoBehaviour
{
    [Header("Groups")]
    [SerializeField]private int _index = 0;
    public float timeToSpawnEnemies = 3f;
    public List<GameObject> enemyToSpawn;
    private float currentTime;
    
    [Header("Boss")]
    public GameObject BossPrefab;
    public float timeToSpawnBoss;
    public Transform bossSpawnPosition;
    private bool _isBossSpawn;//sin esto spawnea 1 vez por frame
    
    private void Start()
    {
        currentTime = 0f;
        _index = 0;
        GameManager.instance.OnLevelReset.AddListener(ResetSpawner);
        if (bossSpawnPosition == null)
            bossSpawnPosition = transform;
    }
    
    private void Update()
    {
        
        if (currentTime >= timeToSpawnEnemies && !_isBossSpawn)
        {
            SpawnGroup();
            currentTime = 0f;
        }
        currentTime += Time.deltaTime;
        
        if(GameManager.instance.currentGameTime >= timeToSpawnBoss && !_isBossSpawn)
            SpawnBoss();
        

    }

    private void SpawnGroup()
    {
        if(enemyToSpawn.Count==0) return;
        if (_index>=enemyToSpawn.Count) _index=0 ;
        Instantiate(enemyToSpawn[_index],transform.position,Quaternion.identity);
        _index++;
    }
    
    public void SpawnBoss()
    {
        if (!BossPrefab) return;
        Instantiate(BossPrefab, bossSpawnPosition);
        _isBossSpawn = true;
    }
    private void ResetSpawner()
    {
        _index = 0;
    }
}
