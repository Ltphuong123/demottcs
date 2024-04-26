using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movea : MonoBehaviour
{
    [SerializeField]protected float radiusX = 1f; 
    [SerializeField]protected float radiusY = 0.5f; 
    [SerializeField]protected float speed = 1f; 
    [SerializeField]protected Vector3 centerPosition; 
    [SerializeField]protected float angle = 0f;
    [SerializeField] protected float rotationAngle=0.1f;
    

    void Start()
    {
        centerPosition = transform.position;
        Vector3 direction = centerPosition - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x);
    }

    void Update()
    {
        float x =  centerPosition.x+Mathf.Cos(angle) * radiusX;
        float y =centerPosition.y+ Mathf.Sin(angle) * radiusY;
        Vector3 newPosition = new Vector3(x, y, transform.position.z);
        transform.position = newPosition;

        angle += speed * Time.deltaTime;
        if (angle > Mathf.PI *2)
        {
            angle -= Mathf.PI * 2;
        }
        transform.rotation= Quaternion.Euler(0f, 0f, Mathf.Cos(angle)*rotationAngle);
    }
}
