using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField]protected float radius = 5f; 
    [SerializeField]protected float speed = 2f; 
    [SerializeField]protected Vector3 centerPosition; 
    [SerializeField]protected float angle = 0f;
    

    void Start()
    {
        centerPosition = transform.parent.position;
        Vector3 direction = centerPosition - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x);
    }

    void Update()
    {
        float x =  centerPosition.x+Mathf.Cos(angle) * radius;
        float y =centerPosition.y+ Mathf.Sin(angle) * radius;
        Vector3 newPosition = new Vector3(x, y, transform.position.z);
        transform.position = newPosition;

        angle += speed * Time.deltaTime;
        if (angle > Mathf.PI * 2)
        {
            angle -= Mathf.PI * 2;
        }
    }
}
