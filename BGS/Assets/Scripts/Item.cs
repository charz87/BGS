using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Staff,
        Sword,
        FishingRod,
        Potion,
        Scroll,
        Meat,
        MagicEssence,
        Heart,
        Diamond
    }

    public static int GetCost(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Staff:     return 30;
            case ItemType.Sword:     return 20;
            case ItemType.FishingRod: return 5;
            case ItemType.Potion:    return 3;
            case ItemType.Scroll:    return 50;
            case ItemType.Meat:      return 10;
            case ItemType.MagicEssence:  return 70;
            case ItemType.Heart:     return 50;
            case ItemType.Diamond:   return 100;

        }
    }
    
    public static Sprite GetItemSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Staff: return GameAssets.Instance.sprStaff;
            case ItemType.Sword: return GameAssets.Instance.sprSword;
            case ItemType.FishingRod: return GameAssets.Instance.sprFishingRod;
            case ItemType.Potion: return GameAssets.Instance.sprPotion;
            case ItemType.Scroll: return GameAssets.Instance.sprScroll;
            case ItemType.Meat: return GameAssets.Instance.sprMeat;
            case ItemType.MagicEssence: return GameAssets.Instance.sprMagicEss;
            case ItemType.Heart: return GameAssets.Instance.sprHeart;
            case ItemType.Diamond: return GameAssets.Instance.sprDiamond;

        }
    }
}
