using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtrasMenuScript : MonoBehaviour
{
    public string back;
    public string lore;
    public GameObject panel;

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

    public void GoToLore()
    {
        SceneManager.LoadScene(lore);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToAchievements()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Achievements.DisplayAchievements();
        else
            PromptSignIn();
    }

    public void DisplayLeaderboard()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Leaderboards.DisplayLeaderboard();
        else
            PromptSignIn();
    }

    public void GoToSkins()
    {
        SceneManager.LoadScene("SkinSelection");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }



    public void PromptSignIn()
    {
        panel.SetActive(true);
    }

    public void SignIn()
    {
        Authentication.AttemptSignIn();
        panel.SetActive(false);
    }

}
