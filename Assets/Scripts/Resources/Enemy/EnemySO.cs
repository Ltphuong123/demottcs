using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName ="ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName = "Enemy";
    public int hpMax;
    public Sprite sprite;
    public List<DropRate> dropRates;
}
