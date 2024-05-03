using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

public class SpawnPoint : MonoBehaviour
{
    private static SpawnPoint instance;
    public static SpawnPoint Instance {get=>instance;}
    [SerializeField] protected List<Transform> points;

    void Awake()
    {
        SpawnPoint.instance=this;
    }

    void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            points.Add(child);
        }
    }
    

    public virtual Transform GetRandomPoint(){
        return this.points[Random.Range(0,this.points.Count)];
    }

    public virtual Transform GetsquadronPoint(){
        return this.points[0];
    }
    public virtual Transform GetPoint(int i){
        return this.points[i];
    }
    public virtual List<Transform> GetListpoint(){

        List<Transform> GetListpoint = new List<Transform>();
        GetListpoint.Add(GetRandomPoint());
        return GetListpoint;
    }
}
