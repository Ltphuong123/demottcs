using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : Spawner
{
    private static ItemSpawn instance;
    public static ItemSpawn Instance {get=>instance;}

    void Awake()
    {
        ItemSpawn.instance=this;
    }
    public void Spawn(List<DropRate> dropRates,Vector3 spawnPos, Quaternion rotation){
        foreach( DropRate dropRate in dropRates){
            float randomValue = Random.value;

            if ( randomValue<= dropRate.dropRate)
            {
                Transform prefab= this.prefabs[0];
                Transform newPrefab = this.GetObjectFromPool(prefab);
                newPrefab.gameObject.GetComponent<ItemCtrl>().resetItem(dropRate.itemSO);
                newPrefab.SetPositionAndRotation(spawnPos,Quaternion.Euler(0f, 0f, 0f));
                newPrefab.parent =this.holder;
                newPrefab.gameObject.SetActive(true);
            }
            
        }
        
    }
}
