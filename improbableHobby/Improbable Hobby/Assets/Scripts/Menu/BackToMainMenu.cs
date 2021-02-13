using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public GameObject gameManager;
    public string mainMenu;

    public void BackToMain()
    {
        SceneManager.LoadScene(mainMenu);

        //resets game
        GameManager manage = gameManager.GetComponent<GameManager>();
        // manage.restartGame();       
    }

    public void OpenLeaderboards()
    {
        Leaderboards.DisplayLeaderboard();
    }
}
