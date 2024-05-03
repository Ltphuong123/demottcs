using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : MonoBehaviour
{

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected JunkOS junkOS;
    protected void Awake()
    {
        Reset();
    }
    protected void Reset()
    {
        this.spriteRenderer = transform.Find("SpriteRenderer").gameObject.GetComponent<SpriteRenderer>();
        this.enemyDamageReceiver = transform.Find("EnemyDamageReceiver").gameObject.GetComponent<EnemyDamageReceiver>();
    }
    protected void Update()
    {
        OnDead();
    }
    protected virtual void OnDead()
    {   
        if(enemyDamageReceiver.isDead){
            ItemSpawn.Instance.Spawn(junkOS.dropRates,transform.position, transform.rotation);
            JunkSpawner.Instance.Despawn(transform);
            FXSpawner.Instance.Spawn(0,transform.position, transform.rotation);
            this.enemyDamageReceiver.isDead=false;
        }
    }


    public void resetJunk(JunkOS junkOS){
        this.junkOS=junkOS;
        this.enemyDamageReceiver.SetEnemyDamageReceiver(junkOS.hpMax);
        this.spriteRenderer.sprite=junkOS.sprite;
    }
}
