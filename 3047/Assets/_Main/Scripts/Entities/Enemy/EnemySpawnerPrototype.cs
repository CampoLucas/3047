using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPrototype : MonoBehaviour
{
    [Header("Groups Spawn")]
    [SerializeField]private int _index = 0;
    public float spawnInterval = 3f;
    public List<GameObject> PrefabToSpawn;
    private float currentTime;
    
    [Header("Boss Spawn")]
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
        if (currentTime >= spawnInterval && !_isBossSpawn)
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
        if(PrefabToSpawn.Count==0) return;
        if (_index>=PrefabToSpawn.Count) _index=0 ;
        Instantiate(PrefabToSpawn[_index],transform.position,Quaternion.identity);
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
