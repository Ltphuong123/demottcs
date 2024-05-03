using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Squadron", menuName ="ScriptableObject/Squadron")]
public class SquadronSO : ScriptableObject
{
    public float radiusX = 0;
    public float radiusY = 0;
    public float speed = 0; 
    public float rotationAngle=0;
    public Vector3 positionSquadron;
    public Vector3 SpawnPositionSquadron;
    public List<InfoEnemy> infoEnemys;
}
