using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    [SerializeField] protected ItemPickupable itemPickupable;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected void Awake()
    {
        Reset();
    }
    protected void Reset()
    {
        spriteRenderer = transform.Find("ItemSpriteRenderer").gameObject.GetComponent<SpriteRenderer>();
        itemPickupable = transform.Find("ItemPickupable").gameObject.GetComponent<ItemPickupable>();
    }

    public void resetItem(ItemSO itemSO){
        spriteRenderer.sprite=itemSO.itemSprite;
        itemPickupable.setItemSO(itemSO);
    }
}
