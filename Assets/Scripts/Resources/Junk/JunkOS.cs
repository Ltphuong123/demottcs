using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Junk", menuName ="ScriptableObject/Junk")]
public class JunkOS : ScriptableObject
{
    public String junkname = "junk";
    public int hpMax;
    public Sprite sprite;
    public List<DropRate> dropRates;
}
