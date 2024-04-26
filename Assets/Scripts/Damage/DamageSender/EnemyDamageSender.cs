using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    public override void Send(Transform obj)
    {
        PlayerDamageReceiver PlayerDamageReceiver = obj.GetComponentInChildren<PlayerDamageReceiver>();
        if (PlayerDamageReceiver == null) return;
        this.Send(PlayerDamageReceiver);
        BulletSpawner.Instance.Despawn(transform.parent);
    }
    public virtual void Send(PlayerDamageReceiver PlayerDamageReceiver)
    {
        PlayerDamageReceiver.Deduct(this.damage);
        FXSpawner.Instance.Spawn(1,transform.parent.position, transform.parent.rotation);
    }
}
