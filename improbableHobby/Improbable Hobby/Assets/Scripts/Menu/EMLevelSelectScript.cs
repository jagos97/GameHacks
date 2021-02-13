using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EMLevelSelectScript : MonoBehaviour
{
    public string level1;
    public string level2;
    public string level3;
    public string level4;
    public string back;
    static string levelToLoad;

    public GameObject loading;

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

    public void GoToLevel1()
    {
        GameTracker.CurrentLevel = 1;
        levelToLoad = level1;
        LoadLevel();
    }

    public void GoToLevel2()
    {
        GameTracker.CurrentLevel = 2;
        levelToLoad = level2;
        LoadLevel();

    }

    public void GoToLevel3()
    {
        /*
        GameTracker.CurrentLevel = 3;
        SceneManager.LoadScene(level3);
        */
    }

    public void GoToLevel4()
    {
        /*
        GameTracker.CurrentLevel = 4;
        SceneManager.LoadScene(level4);
        */
    }

    private void LoadLevel()
    {
        loading.SetActive(true);
        StartCoroutine(LoadInBackground());
    }

    public IEnumerator LoadInBackground()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(levelToLoad);
        while(gameLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }

        
    }

    public void GoBack()
    {
        SceneManager.LoadScene(back);
    }
}
