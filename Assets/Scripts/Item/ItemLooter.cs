using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemLooter : MonoBehaviour
{
    [SerializeField] protected List<ItemSO> itemSOs;
    [SerializeField] protected ShipShooting shipShooting;
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    [SerializeField] protected Score score;
    [SerializeField]private AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        loot(other.transform);
    }
    public virtual void loot(Transform obj)
    {
        ItemPickupable itemPickupable = obj.GetComponentInChildren<ItemPickupable>();
        if (itemPickupable == null) return;
        ItemSO itemSO =itemPickupable.sendItem();
        if(itemSO.name=="iron"){
            shipShooting.Add(1);
        }
        if(itemSO.name=="gold"){
            playerDamageReceiver.Add(2);
            shipShooting.Add(1);
        }
        if(itemSO.name=="Score"){
            score.Add(1);
        }
        audioSource.Play();
        itemSOs.Add(itemPickupable.sendItem());
    }
}
