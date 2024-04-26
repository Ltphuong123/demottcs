using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] private int bulletType=1;

    void Update()
    {
        Shooting();
    }
    protected virtual void Shooting(){
        if(this.shootTimer < this.shootDelay){
            shootTimer += Time.deltaTime;
            return;
        }
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        BulletSpawner.Instance.Spawn(bulletType,spawnPos, rotation);
    }
}
