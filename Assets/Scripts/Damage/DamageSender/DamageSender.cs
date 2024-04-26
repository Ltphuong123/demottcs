using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [SerializeField] protected int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        this.Send(other.transform);
    }
    public virtual void Send(Transform obj)
    {
        
    }
}
