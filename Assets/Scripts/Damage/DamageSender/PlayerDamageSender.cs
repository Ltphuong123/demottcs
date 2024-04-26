using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    public override void Send(Transform obj)
    {
        EnemyDamageReceiver enemyDamageReceiver = obj.GetComponentInChildren<EnemyDamageReceiver>();
        if (enemyDamageReceiver == null) return;
        this.Send(enemyDamageReceiver);
        BulletSpawner.Instance.Despawn(transform.parent);
    }
    public virtual void Send(EnemyDamageReceiver enemyDamageReceiver)
    {
        enemyDamageReceiver.Deduct(this.damage);
        FXSpawner.Instance.Spawn(1,transform.parent.position, transform.parent.rotation);
    }
}