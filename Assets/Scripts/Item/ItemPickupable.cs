using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupable : MonoBehaviour
{
    protected ItemSO itemSO;
    public void setItemSO(ItemSO itemSO){
        this.itemSO=itemSO;
    }
    public ItemSO sendItem(){
        ItemSpawn.Instance.Despawn(transform.parent);
        return this.itemSO;
    }
}
