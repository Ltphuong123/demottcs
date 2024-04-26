using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance {get=>instance;}
    
    [SerializeField]protected List<JunkOS> junkSO;
    void Awake()
    {
        JunkSpawner.instance=this;
    }
    void Start()
    {
        this.Spawn();
        
    }
    public void Spawn(){
  
        List<Transform> pawnerPoints= SpawnPoint.Instance.GetListpoint();
        foreach(Transform pawnerPoint in  pawnerPoints){
            Transform prefab= this.prefabs[0];
            Transform newPrefab = this.GetObjectFromPool(prefab);

            Vector3 position= pawnerPoint.position;
            Quaternion rotation=Quaternion.Euler(0f, 0f, (float)Random.Range(-30,30)*1f);
            newPrefab.SetPositionAndRotation(position,rotation);
            newPrefab.parent =this.holder;
            newPrefab.gameObject.GetComponent<JunkCtrl>().resetJunk(junkSO[Random.Range(0,this.junkSO.Count)]);
            newPrefab.gameObject.SetActive(true);
        }

        Invoke(nameof(Spawn),3f);
    }
}
