using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    public virtual void reset(int hpMax){
        this.hpMax=hpMax;
        this.hp=this.hpMax;
    }

}
