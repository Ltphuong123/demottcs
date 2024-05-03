using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] private int bulletType=1;
    [SerializeField] protected Vector3 target;

    

    void Update()
    {
        target=inputManager.Instance.Pos;
        Shooting();
    }
    protected virtual void Shooting(){
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(this.shootTimer < this.shootDelay){
            shootTimer += Time.deltaTime;
            return;
        }
        this.shootTimer = 0;
        shootDelay=Random.Range(2,5);

        Vector3 spawnPos = transform.position;
        // Quaternion rotation = transform.parent.rotation;
        Quaternion rotation = transform.rotation;
        BulletSpawner.Instance.Spawn(bulletType,spawnPos, rotation);
    }
}
