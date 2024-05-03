using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class  MoveSquadron : MonoBehaviour
{
    [SerializeField]protected float radiusX; 
    [SerializeField]protected float radiusY; 
    [SerializeField]protected float speed;  
    [SerializeField]protected float rotationAngle;
    [SerializeField]protected Vector3 positionSquadron; 
    [SerializeField]protected List<InfoEnemy> infoEnemys;

    protected float angle=0f; 
    protected Vector3 centerPosition;

    public void SetSquadron(SquadronSO squadronSO)
    {
        this.radiusX=squadronSO.radiusX;
        this.radiusY = squadronSO.radiusY;
        this.speed = squadronSO.speed; 
        this.rotationAngle=squadronSO.rotationAngle;
        this.infoEnemys=squadronSO.infoEnemys;
        this.positionSquadron=squadronSO.positionSquadron;
        this.centerPosition=squadronSO.SpawnPositionSquadron;

        this.SpawnEnemy(infoEnemys);
    }

    public void SpawnEnemy(List<InfoEnemy> infoEnemys){
        foreach (InfoEnemy infoEnemy in infoEnemys){
            Transform enemy = EnemySpawner.Instance.Spawn(infoEnemy);
            enemy.parent = this.transform;
        }   
    }
    

    protected void Update()
    {
        Check();
        Move();
    }

    protected void Move(){
        centerPosition=Vector3.Lerp(centerPosition,positionSquadron, speed * Time.deltaTime);

        float x =  centerPosition.x+Mathf.Cos(angle) * radiusX;
        float y =centerPosition.y+ Mathf.Sin(angle) * radiusY;
        
        transform.position = new Vector3(x, y, transform.position.z);

        angle += speed * Time.deltaTime;
        if (angle > Mathf.PI *2)
        {
            angle -= Mathf.PI * 2;
        }
        transform.rotation= Quaternion.Euler(0f, 0f, Mathf.Cos(angle)*rotationAngle);
    }

    protected void Check(){
        if (transform.childCount==0){
            EnemySpawner.Instance.DespawnSquad(this.transform);
        }
    }


}
