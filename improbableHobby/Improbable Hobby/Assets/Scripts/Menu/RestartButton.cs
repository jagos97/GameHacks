using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject gameManager;

    public void RestartGame()
    {
        GameManager manage = gameManager.GetComponent<GameManager>();
        manage.restartGame();
    }
}
