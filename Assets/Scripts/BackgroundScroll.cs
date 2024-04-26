using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] protected float moveSpeed=1f;
    protected Vector3 direction=Vector3.down;
    void Update()
    {
        transform.Translate(this.direction*this.moveSpeed*Time.deltaTime);
        if(transform.position.y<=-5){
            transform.position=new Vector3(0,5,0);
        }
    }
}
