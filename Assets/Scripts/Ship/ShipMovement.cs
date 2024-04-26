using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 5f;
    

    void Update()
    {
        this.GetTargetPos();

        this.Moving(); 

    }
    protected virtual void GetTargetPos(){
        this.targetPos = inputManager.Instance.Pos;
        this.targetPos.z = 0;
    }
    protected virtual void Moving(){
        Vector3 newPos = Vector3.Lerp(transform.parent.position,targetPos,this.speed*Time.deltaTime);
        transform.parent.position = newPos;
    }
}
