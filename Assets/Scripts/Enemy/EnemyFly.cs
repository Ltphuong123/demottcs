using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] protected Transform targetPoint; 
    [SerializeField] protected float moveSpeed = 2f; 

    public void SetTarget(Transform targetPoint){
        this.targetPoint=targetPoint;
    }

    void Update()
    {
        if (targetPoint != null)
        {
            transform.parent.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        }
    }
}
