using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    //If time is paused while in pause menu and sent back to main menu time will stay paused 

    public GameObject gameManager;
    public string mainMenu;
    public GameObject pauseMenu;
    public GameObject pauseButton;


    public void RestartGame()
    {
        GameManager manage = gameManager.GetComponent<GameManager>();
        manage.restartGame();
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        GameManager manage = gameManager.GetComponent<GameManager>();
        //manage.restartGame();
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;
        SceneManager.LoadScene(mainMenu);
        
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

}
