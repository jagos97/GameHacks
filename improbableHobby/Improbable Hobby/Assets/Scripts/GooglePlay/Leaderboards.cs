using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Leaderboards : MonoBehaviour
{
    /**
     *Uses the playerpref of highscore to update the leaderboard
     */
    public static void SubmitScoreToLeaderboard(float score)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore((int)score, GPGSIds.leaderboard_highscore, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Score updated sucessfully");
                }
            }
            );
        }
    }


    public static void DisplayLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_highscore);
        }
        else
        {
            //display an error message or something idk
        }
    }

}
