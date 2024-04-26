using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected EnemyFly enemyFly;
    protected EnemySO enemySO;
    protected void Awake()
    {
        Reset();
    }
    protected void Reset()
    {
        spriteRenderer = transform.Find("SpriteRenderer").gameObject.GetComponent<SpriteRenderer>();
        enemyDamageReceiver = transform.Find("EnemyDamageReceiver").gameObject.GetComponent<EnemyDamageReceiver>();
        enemyFly = transform.Find("EnemyFly").gameObject.GetComponent<EnemyFly>();

    }
    protected void Update()
    {
        OnDead();
    }
    protected virtual void OnDead()
    {   
        if(enemyDamageReceiver.isDead){
            ItemSpawn.Instance.Spawn(enemySO.dropRates,transform.position, transform.rotation);
            EnemySpawner.Instance.Despawn(transform);
            FXSpawner.Instance.Spawn(0,transform.position, transform.rotation);
            enemyDamageReceiver.isDead=false;
        }
    }


    public void resetEnemy(EnemySO enemySO,Transform targetPoint){
        this.enemySO=enemySO;
        enemyDamageReceiver.reset(enemySO.hpMax);
        spriteRenderer.sprite=enemySO.sprite;
        enemyFly.SetTarget(targetPoint);
    }
}
