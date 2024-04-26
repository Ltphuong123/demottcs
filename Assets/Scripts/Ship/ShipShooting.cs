using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] private int bulletType=0;
    [SerializeField] public int shootingLevel=1;
    [SerializeField] protected float rotationAngle;
    [SerializeField] protected List<Transform> ListShootingPos;
    

    void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            ListShootingPos.Add(child);
        }
    }
    public virtual void Add(int add)
    {
        
        this.shootingLevel += add;
        if (this.shootingLevel > 9) this.shootingLevel = 9;
    }

    void Update()
    {
        RotationShooting(this.rotationAngle);
        Shooting();
    }
    protected virtual void Shooting(){
        float shooting=inputManager.Instance.OnFiring;
        if(this.shootTimer < this.shootDelay) shootTimer += Time.deltaTime;

        if(shooting == 0) return;
        if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        if(shootingLevel % 2 ==1){
            for (int i = 0; i < shootingLevel; i++){
                Transform ShootingPos=ListShootingPos[i];
                Shoot(ShootingPos);
            }  
        }
        else{
            for (int i = 1; i < shootingLevel+1; i++){
                Transform ShootingPos=ListShootingPos[i];
                Shoot(ShootingPos);
            }  
        }
    }
    protected void Shoot(Transform ShootingPos){
        Vector3 spawnPos = ShootingPos.position;
        Quaternion rotation = ShootingPos.rotation;
        BulletSpawner.Instance.Spawn(bulletType,spawnPos, rotation);
    }
    protected void RotationShooting(float rotationAngle){
        for (int i = 1; i < ListShootingPos.Count; i++){
            if(i<3){
                RotationShoot(i,rotationAngle/2);
            }
            else RotationShoot(i,rotationAngle);
        }
    }
    protected void RotationShoot(int i,float rotationAngle){
        if(i % 2 == 1){
            ListShootingPos[i].transform.rotation= Quaternion.Euler(0f, 0f, -((i/2)+1)*rotationAngle);
        }
        if(i % 2 == 0){
            ListShootingPos[i].transform.rotation= Quaternion.Euler(0f, 0f, (i/2)*rotationAngle);
        }
    }
}

