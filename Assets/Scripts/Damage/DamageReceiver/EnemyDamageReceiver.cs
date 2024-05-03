using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    public virtual void SetEnemyDamageReceiver(int hpMax){
        this.hpMax=hpMax;
        this.hp=this.hpMax;
    }

}
