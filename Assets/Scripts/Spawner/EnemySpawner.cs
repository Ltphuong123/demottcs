using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance {get=>instance;}
    
    [SerializeField]protected List<EnemySO> enemySOs;
    [SerializeField]protected List<Transform> Squads;

    void Awake()
    {
        EnemySpawner.instance=this;
    }

    void Start()
    {
        this.SpawnManager();
    }
    public void Spawn(Transform targetPoint){
        
        Transform prefab= this.prefabs[0];
        Transform newPrefab = this.GetObjectFromPool(prefab);

        Transform spawnerPoints= SpawnPoint.Instance.GetRandomPoint();
        
        Vector3 position= spawnerPoints.position;
        Quaternion rotation=spawnerPoints.rotation;

        newPrefab.SetPositionAndRotation(position,rotation);
        newPrefab.parent =this.holder;
        newPrefab.gameObject.GetComponent<EnemyCtrl>().resetEnemy(enemySOs[Random.Range(0,this.enemySOs.Count)], targetPoint);
        newPrefab.gameObject.SetActive(true); 
    }
    protected void SpawnManager(){
        Transform Squad=Squads[Random.Range(0,this.Squads.Count)];
        foreach (Transform child in Squad)
        {
           Spawn(child);
        }
        Invoke(nameof(SpawnManager),Random.Range(10,20));
    }
}
