using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField]public float radius; 
    [SerializeField]public float speed; 
    [SerializeField]protected Vector3 centerPosition; 
    [SerializeField]protected float angle=0f;
    [SerializeField]public int moveCase;
    InfoEnemy infoEnemy;
    bool a=false;

    public void SetEnemyFly(InfoEnemy infoEnemy)
    {
        this.radius=infoEnemy.radius;
        this.speed=infoEnemy.speed;
        this.moveCase=infoEnemy.moveCase;
        this.infoEnemy=infoEnemy;
        a=false;

        angle = Mathf.Atan2(infoEnemy.enemyPosition.y, infoEnemy.enemyPosition.x);
    }
  

    protected void Update(){
        if(moveCase==0) moveCase0();
        if(moveCase==1) moveCase1();
    }
    void moveCase0(){
        if(a) return;
        if(transform.parent.position==transform.parent.parent.position+infoEnemy.enemyPosition){
            a=true;
            return;
        }
        transform.parent.position=Vector3.MoveTowards(transform.parent.position,transform.parent.parent.position+infoEnemy.enemyPosition, speed * Time.deltaTime);
    }
    void moveCase1(){
        centerPosition = transform.parent.parent.position;
        float x =  centerPosition.x+Mathf.Cos(angle) * radius;
        float y =centerPosition.y+ Mathf.Sin(angle) * radius;
        transform.parent.position = new Vector3(x, y, transform.parent.position.z);
        transform.parent.rotation= Quaternion.Euler(0f, 0f, angle*180/Mathf.PI);
        angle += (speed/radius) * Time.deltaTime;
        if (angle > Mathf.PI *2)
        {
            angle -= Mathf.PI * 2;
        }
    }
}
