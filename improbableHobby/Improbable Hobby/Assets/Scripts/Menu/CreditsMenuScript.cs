using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuScript : MonoBehaviour
{
    public string back;

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
    }

    public void GoBack()
    {
        SceneManager.LoadScene(back);
    }
}
