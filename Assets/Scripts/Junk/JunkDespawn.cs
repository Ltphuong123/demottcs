using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : Despawn
{
    public override void DespawnObj()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

}
