using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance {get=>instance;}
    

    void Awake()
    {
        BulletSpawner.instance=this;
    }
    public void Spawn(int prefabType,Vector3 spawnPos, Quaternion rotation){
        Transform prefab= this.prefabs[prefabType];
        
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos,rotation);
        newPrefab.parent =this.holder;
        newPrefab.gameObject.SetActive(true);
    }

}
