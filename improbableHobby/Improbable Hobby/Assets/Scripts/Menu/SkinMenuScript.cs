using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinMenuScript : MonoBehaviour
{
    public string back;
    public List<Image> skinList;
    public static int currentSkin;

    public Text descriptionField;
    public Text nameField;


    /// <summary>
    /// To Verufy purchase of skin
    /// </summary>
    public GameObject unlockPrompt;
    public TextMeshProUGUI unlockText;
    public GameObject buyButton;


    /// <summary>
    /// To show confirmation of successful or unsucessful purchase of skin
    /// </summary>
    public GameObject popUp;
    public TextMeshProUGUI confirmationText;


    public Image skinSelector;

    //this makes it much easier in code
    public Image skin0;
    public Image skin1;
    public Image skin2;
    public Image skin3;
    public Image skin4;


    public Canvas canvas;

    public static SkinProperties skinProperties;

    public void Start()
    {
        skinProperties = canvas.GetComponent<SkinProperties>();
        skinList.Add(skin0);
        skinList.Add(skin1);
        skinList.Add(skin2);
        skinList.Add(skin3);
        skinList.Add(skin4);

        for(int i = 0; i < skinList.Count; i++)
        {
            if (PlayerPrefs.GetInt(IDs.hasSkin + i, 0) == 0)
            {
                skinList[i].color = Color.black;
            }
        }

        //sets the yellow frame to the currently equipped skin
        skinSelector.rectTransform.localPosition = skinList[PlayerPrefs.GetInt("SkinID")].rectTransform.localPosition;


        for(int i = 0; i < skinList.Count; i++)
        {
            Debug.Log(skinList[i].ToString());
        }

        Debug.Log(PlayerPrefs.GetInt("SkinID"));


        SetTextFields();
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))    //if back arrow is pushed on Android, go back
            {
                GoBack();

                return;
            }
        }
        skinSelector.rectTransform.localPosition = skinList[PlayerPrefs.GetInt("SkinID")].rectTransform.localPosition;
    }

    public void SetTextFields()
    {
        string name = skinProperties.GetSkinName(PlayerPrefs.GetInt("SkinID"));
        string desc = skinProperties.GetSkinDescription(PlayerPrefs.GetInt("SkinID"));

        Debug.Log(name);
        Debug.Log(desc);


        nameField.text = name;
        descriptionField.text = desc;
    }

    public void SelectSkin(Image selectedSkin)
    {
        //skinID is the position of the skin in the skinList array list
        int newSkin = skinList.FindIndex(o=>o == selectedSkin); //lambda expression for compatibility stuff
        if(PlayerPrefs.GetInt(IDs.hasSkin + newSkin, 0) == 1)
        {
            SetSkin(newSkin);
            buyButton.SetActive(false);
        }
        else
        {
            currentSkin = newSkin;
            SetUnlockMessage(newSkin);
            buyButton.SetActive(true);
            
        }

    }

    public void SetSkin(int newSkin)
    {
        PlayerPrefs.SetInt("SkinID", newSkin);

        skinSelector.rectTransform.localPosition = skinList[PlayerPrefs.GetInt("SkinID")].rectTransform.localPosition;

        SetTextFields();

        Debug.Log("CURRENT SKIN-ID IN PLAYERPREFS: " + PlayerPrefs.GetInt("SkinID"));
    }





    public void SetUnlockMessage(int newSkin)
    {

        skinSelector.rectTransform.localPosition = skinList[newSkin].rectTransform.localPosition;

        string name = skinProperties.GetSkinName(newSkin);
        string desc = skinProperties.GetSkinConditions(newSkin);

        Debug.Log(name);
        Debug.Log(desc);


        nameField.text = name;
        descriptionField.text = desc;

    }


    public void BuySkin()
    {
        unlockPrompt.SetActive(true);
        unlockText.text = "Are you sure you want to unlock " + skinProperties.GetSkinName(currentSkin) + " for " + skinProperties.GetSkinPrice(currentSkin) + " coins?";
    }

    public void Cancel()
    {
        unlockPrompt.SetActive(false);
    }

    public void Buy()
    {
        if(PlayerPrefs.GetInt(IDs.coins, 0) >= skinProperties.GetSkinPrice(currentSkin))
        {
            PlayerPrefs.SetInt(IDs.hasSkin + currentSkin, 1);
            PlayerPrefs.SetInt(IDs.coins, PlayerPrefs.GetInt(IDs.coins) - skinProperties.GetSkinPrice(currentSkin));
            popUp.SetActive(true);
            confirmationText.text = "You now have: " + skinProperties.GetSkinName(currentSkin) + "\n Congratulations!!";
        }
        else
        {
            popUp.SetActive(true);
            confirmationText.text = "Not enough coins!";
        }
    }

    public void OK()
    {
        SceneManager.LoadScene("SkinSelection");
    }



    public void GoBack()
    {
        SceneManager.LoadScene(back);
    }

}
