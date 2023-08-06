using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static GameAssets Instance
    {
        get
        {
            return _instance;
        }
    }

    public Sprite sprStaff;
    public Sprite sprSword;
    public Sprite sprFishingRod;
    public Sprite sprPotion;
    public Sprite sprScroll;
    public Sprite sprMeat;
    public Sprite sprMagicEss;
    public Sprite sprHeart;
    public Sprite sprDiamond;

}
