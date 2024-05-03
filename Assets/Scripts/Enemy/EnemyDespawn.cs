using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn
{
    public override void DespawnObj()
    {
        // EnemySpawner.Instance.Despawn(transform.parent);
    }

}
