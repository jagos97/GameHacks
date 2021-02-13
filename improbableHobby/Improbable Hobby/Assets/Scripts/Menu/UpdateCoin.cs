using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "x " + PlayerPrefs.GetInt("Coin", 0).ToString();
    }
}
