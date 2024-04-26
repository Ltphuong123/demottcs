using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageReceiver : DamageReceiver
{
    
    protected void Awake()
    {
        this.isDead = false;
        this.hpMax=10;
        this.hp=10;
    }
    protected void  Reset()
    {
        Awake();
    }
    public float HP(){
        return (float)this.hp /this.hpMax;
    }
    protected override void CheckIsDead(){
        if (!this.IsDead()) return;
        this.isDead = true;
        SceneManager.LoadScene("MainMenu");
    }    
}
