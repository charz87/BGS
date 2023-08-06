using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private UIShop uiShop;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider");
        IShopCostumer shopCostumer = other.GetComponent<IShopCostumer>();
        if(shopCostumer != null)
        {
            uiShop.Show(shopCostumer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IShopCostumer shopCostumer = other.GetComponent<IShopCostumer>();
        if (shopCostumer != null)
        {
            uiShop.Hide();
        }
    }

}
