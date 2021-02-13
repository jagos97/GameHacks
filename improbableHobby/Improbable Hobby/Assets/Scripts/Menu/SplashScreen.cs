using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour
{
    public string mainMenu;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))    //if back arrow is pushed on Android, go back
            {
                Application.Quit();

                return;
            }
        }
    }

}
