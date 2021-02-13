using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Authentication : MonoBehaviour
{
    public static PlayGamesPlatform platform;
    public static bool bGoogleCheck = false;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        if (!bGoogleCheck && PlayerPrefs.GetInt(IDs.signInChoice, 1) == 1) ;
        {      // internal flag to do this only once if user is offline
            GoogleSignin();
        }
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayerPrefs.SetInt(IDs.signInChoice, 0);
        }
        bGoogleCheck = true;
        
        // Mark it done until the game is restarted again
    }

    public void GoogleSignin()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate(success => {
                if (success)
                {
                    Debug.Log("Log in successful");
                    PlayerPrefs.SetInt(IDs.signInChoice, 1);

                }
            });
        }
    }


    public  static void AttemptSignIn()
    {
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Log in successful");
                PlayerPrefs.SetInt(IDs.signInChoice, 1);
            }
        });
    }

    public void Cancel()
    {
        panel.SetActive(false);
    }




}
