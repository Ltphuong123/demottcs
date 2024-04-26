using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{    
    public string itemName= "Item";
    public Sprite itemSprite;
    
}
