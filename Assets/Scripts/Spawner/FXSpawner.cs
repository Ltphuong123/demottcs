using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance {get=>instance;}
    

    void Awake()
    {
        FXSpawner.instance=this;
    }
    public Transform Spawn(int prefabType,Vector3 spawnPos, Quaternion rotation){
        Transform prefab= this.prefabs[prefabType];
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos,rotation);
        newPrefab.parent =this.holder;
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

}
