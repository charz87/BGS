using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    
    public UIShop uiShop;
    public Item.ItemType itemType;

    public void OnClickTryBuyItem()
    {
        uiShop.TryBuyItem(itemType);
    }

}
