using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    private Transform container;

    public GameObject shopItem;

    private IShopCostumer shopCostumer;
    
    private void Awake()
    {
        container = transform.Find("Container");
        shopItem.gameObject.SetActive(true);
    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Staff,Item.GetItemSprite(Item.ItemType.Staff), "Staff", Item.GetCost(Item.ItemType.Staff), 0);
        CreateItemButton(Item.ItemType.Sword,Item.GetItemSprite(Item.ItemType.Sword), "Sword", Item.GetCost(Item.ItemType.Sword), 1);
        CreateItemButton(Item.ItemType.Potion,Item.GetItemSprite(Item.ItemType.Potion), "Potion", Item.GetCost(Item.ItemType.Potion), 2);
        CreateItemButton(Item.ItemType.Scroll,Item.GetItemSprite(Item.ItemType.Scroll), "Scroll", Item.GetCost(Item.ItemType.Scroll), 3);

        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        GameObject shopItemGO = Instantiate(shopItem, container);
        RectTransform shopItemRectTransform = shopItemGO.GetComponent<RectTransform>();
        float shopItemHeight = 70f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);


        shopItemGO.transform.GetComponent<ShopItem>().itemType = itemType;
        shopItemGO.transform.GetComponent<ShopItem>().uiShop = this;
        shopItemGO.transform.GetChild(0).Find("ItemName").GetComponent<Text>().text = itemName;
        shopItemGO.transform.GetChild(0).Find("ItemCost").GetComponent<Text>().text = itemCost.ToString();
        shopItemGO.transform.GetChild(0).Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

     


    }

    public void TryBuyItem(Item.ItemType itemType)
    {
        if(shopCostumer.TrySpendGoldAmount(Item.GetCost(itemType)))
        {
            shopCostumer.BoughtItem(itemType);
        }
        
    }

    public void Show(IShopCostumer shopCostumer)
    {
        this.shopCostumer = shopCostumer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
  
}
