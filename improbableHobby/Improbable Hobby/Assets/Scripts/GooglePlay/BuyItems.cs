using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItems : MonoBehaviour
{

    public void BuyHandful()
    {
        Purchaser purchaser = GameObject.Find("Purchaser").GetComponent<Purchaser>();
        purchaser.BuyHandfull();
    }
    public void BuySmall()
    {
        Purchaser purchaser = GameObject.Find("Purchaser").GetComponent<Purchaser>();
        purchaser.BuySmall();
    }
    public void BuyLarge()
    {
        Purchaser purchaser = GameObject.Find("Purchaser").GetComponent<Purchaser>();
        purchaser.BuyLarge();
    }
    public void BuyChest()
    {
        Purchaser purchaser = GameObject.Find("Purchaser").GetComponent<Purchaser>();
        purchaser.BuyChest();
    }
    public void BuyStarter()
    {
        Purchaser purchaser = GameObject.Find("Purchaser").GetComponent<Purchaser>();
        purchaser.BuyStarter();
    }

}
