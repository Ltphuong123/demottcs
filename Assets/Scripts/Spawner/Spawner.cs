using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField]protected List<Transform> prefabs;
    [SerializeField]protected List<Transform> poolOpjs;

    [SerializeField]protected Transform holder;


    public virtual void Despawn(Transform obj){
        this.poolOpjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual Transform GetObjectFromPool(Transform prefab){
        foreach(Transform poolOpj in this.poolOpjs){
            if(poolOpj.name == prefab.name){
                this.poolOpjs.Remove(poolOpj);
                return poolOpj;
            }
        }
        
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
}
