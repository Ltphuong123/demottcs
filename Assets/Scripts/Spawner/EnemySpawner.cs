using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance {get=>instance;}
    
    [SerializeField]protected List<EnemySO> enemySOs;
    [SerializeField]protected Transform holderSquads;
    [SerializeField]protected List<Transform> Squads;
    [SerializeField]protected List<Transform> poolSquad;
    [SerializeField]protected List<SquadronSO> squadronSOs;
    // [SerializeField] protected float shootDelay = 3f;
    // [SerializeField] protected float shootTimer = 0f;

    void Awake()
    {
        EnemySpawner.instance=this;
    }


    public virtual Transform Spawn(InfoEnemy infoEnemy){
        
        Transform prefab= this.prefabs[0];
        Transform newPrefab = this.GetObjectFromPool(prefab);

        Transform spawnerPoints= SpawnPoint.Instance.GetRandomPoint();
        Vector3 position= spawnerPoints.position;
        Quaternion rotation=spawnerPoints.rotation;
        newPrefab.SetPositionAndRotation(position,rotation);

        newPrefab.gameObject.SetActive(true); 
        newPrefab.gameObject.GetComponent<EnemyCtrl>().resetEnemy(enemySOs[infoEnemy.enemyType],infoEnemy);
        
        return newPrefab;
    }

    protected virtual Transform GetSquadFromPool(Transform prefab){
        foreach(Transform poolOpj in this.poolSquad){
            if(poolOpj.name == prefab.name){
                this.poolSquad.Remove(poolOpj);
                return poolOpj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    
    public virtual void DespawnSquad(Transform obj){
        this.poolSquad.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public override void Despawn(Transform obj){
        base.Despawn(obj);
        obj.parent = this.holder;
    }
   
    // void Update()
    // {
    //     SpawnSquad(Random.Range(0,this.squadronSOs.Count));
    // }
    public void SpawnSquad(int SquadType){

        // if(this.shootTimer < this.shootDelay){
        //     shootTimer += Time.deltaTime;
        //     return;
        // }
        // this.shootTimer = 0;
        // shootDelay=20;

        Transform newsquadron=GetSquadFromPool(Squads[0]);
        newsquadron.gameObject.SetActive(true);
        newsquadron.parent = this.holderSquads;

        newsquadron.GetComponent<MoveSquadron>().SetSquadron(squadronSOs[SquadType]);
    }
}
