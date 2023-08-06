using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour,IShopCostumer
{
    private int goldAmount = 500;
    private int potionAmount = 1;

    public GameObject itemHolder;

    public Text goldAmountUI;
    public Text potionAmountUI;

    public int GetGoldAmount()
    {
        return goldAmount;
    }
    public int GetPotionAmount()
    {
        return potionAmount;
    }

    [SerializeField]
    private float speed = 5f;
    private Rigidbody rb;


    Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateGoldAmount();
        UpdatePotionAmount();

    }
    private void Update()
    {
        //Calculate velocity as 3d Vector
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.z = Input.GetAxisRaw("Vertical");


        anim.SetFloat("Horizontal", velocity.x);
        anim.SetFloat("Vertical", velocity.z);
        anim.SetFloat("Speed", velocity.magnitude);

    }

    //Run every physics iteration
    private void FixedUpdate()
    {
        PerformMovement();
    }
    //Perform movement based on velocity variable

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * speed * Time.fixedDeltaTime);
        }

    }

    void UpdateGoldAmount()
    {
        goldAmountUI.text = goldAmount.ToString();
    }
    void UpdatePotionAmount()
    {
        potionAmountUI.text = potionAmount.ToString();
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
        switch(itemType)
        {
            case Item.ItemType.Staff:  EquipStaff(); break;
            case Item.ItemType.Sword: EquipSword(); break;
            case Item.ItemType.Potion: AddPotion(); break;
            case Item.ItemType.Scroll: EquipScroll(); break;
        }
    }

    private void EquipScroll()
    {
        itemHolder.transform.Find("Scroll").gameObject.SetActive(true);
        itemHolder.transform.Find("Sword").gameObject.SetActive(false);
        itemHolder.transform.Find("Staff").gameObject.SetActive(false);
    }

    private void AddPotion()
    {
        potionAmount++;
        UpdatePotionAmount();
    }

    private void EquipSword()
    {
        itemHolder.transform.Find("Sword").gameObject.SetActive(true);
        itemHolder.transform.Find("Staff").gameObject.SetActive(false);
        itemHolder.transform.Find("Scroll").gameObject.SetActive(false);

    }

    private void EquipStaff()
    {
        itemHolder.transform.Find("Staff").gameObject.SetActive(true);
        itemHolder.transform.Find("Scroll").gameObject.SetActive(false);
        itemHolder.transform.Find("Sword").gameObject.SetActive(false);
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if (GetGoldAmount() >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            UpdateGoldAmount();
            return true;
        }
        else
        {
            Debug.Log("Cannot buy, not enough gold");
            return false;
        }
            

    }
}
