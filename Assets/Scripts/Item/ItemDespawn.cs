using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : Despawn
{
    public override void DespawnObj()
    {
        ItemSpawn.Instance.Despawn(transform.parent);
    }
}

