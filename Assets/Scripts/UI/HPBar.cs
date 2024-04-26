using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] PlayerDamageReceiver playerDamageReceiver;

    void Start(){
        this.slider= transform.Find("Slider").gameObject.GetComponent<Slider>();

    }

    void Update(){
        this.slider.value=this.playerDamageReceiver.HP();
    }
}
