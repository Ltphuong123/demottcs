using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField]private float time = 10f;
    [SerializeField]private float timeSecond; 
    private bool countdownStarted = false; 

    void Update()
    {
        if (countdownStarted)
        {
            timeSecond -= Time.deltaTime;
            if (timeSecond <= 0f)
            {
                DespawnObj();
            }
        }
    }
    void OnEnable()
    {
        countdownStarted = true;
        timeSecond = time;
    }
    public virtual void DespawnObj()
    {
       
    }
}
