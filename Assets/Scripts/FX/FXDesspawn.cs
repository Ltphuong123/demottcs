using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : Despawn
{
    public override void DespawnObj()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
