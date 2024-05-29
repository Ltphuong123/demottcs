using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Vector3 forceDirection; 
    public float forceMagnitude; 

    [SerializeField]private Rigidbody2D rb;

    void OnEnable()
    {
        forceDirection= new Vector3(Random.Range(-0.5f,0.5f),1,0);
        forceMagnitude=Random.Range(2,4);
        
        rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Impulse);
    }

}
