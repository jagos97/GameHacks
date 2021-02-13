using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string endlessModeLevelSelect;
    public string storyModeLevelSelect;
    public string settings;
    public string extras;
    public string skins;
    public GameObject purchases;

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name.Equals("MainMenu"))    //if back arrow is pushed on Android, go back
            {
                Application.Quit();

                return;
            }
        }
    }

    public void GoToEMLevelSelect()
    {
        SceneManager.LoadScene(endlessModeLevelSelect);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(settings);
    }

    //holds about us, contributors, thanks, etc
    public void GoToExtras()
    {
        SceneManager.LoadScene(extras);
    }

    public void GoToSkins()
    {
        SceneManager.LoadScene(skins);
    }

    public void OpenPurchases()
    {
        purchases.SetActive(true);
    }

    public void ExitPurchase()
    {
        purchases.SetActive(false);
    }
}
