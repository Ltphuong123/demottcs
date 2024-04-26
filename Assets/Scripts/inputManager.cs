using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    protected static inputManager instance;
    public static inputManager Instance {get=>instance;}
    [SerializeField] protected Vector3 pos;
    public Vector3 Pos {get=>pos;}
    [SerializeField] protected float onFiring;
    public float OnFiring {get=>onFiring;}

    
    void Awake()
    {
        inputManager.instance=this;
    }

    void Update()
    {
        this.GetPos();
        this.GetFire();
    }
    protected virtual void GetPos()
    {
        this.pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected virtual void GetFire()
    {
        this.onFiring=Input.GetAxis("Fire1");
    }

}
