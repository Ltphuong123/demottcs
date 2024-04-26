using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : MonoBehaviour
{
    [SerializeField] protected float moveSpeed=2f;
    protected Vector3 direction=Vector3.down;
    void Update()
    {
        transform.parent.Translate(this.direction*this.moveSpeed*Time.deltaTime);
    }
}
