
using UnityEngine;
using GooglePlayGames;

public class Achievements : MonoBehaviour
{
    /**
     * Methods are static so can be called from anywhere.
     * I think calling them more than once is ok they just won't do anything
     * it shouldn't cause an error.
     * Once an achievement is unlocked it will unlock its respective skin
     */


    public static void UnlockIBelieveICanFly()
    {
        Social.ReportProgress(GPGSIds.achievement_i_believe_i_can_fly, 100f, null);
        PlayerPrefs.SetInt("Fly", 1); // will be used to unlock skins
        
    }

    public static void UnlockGodMode()
    {
        Social.ReportProgress(GPGSIds.achievement_god_mode, 100f, null);
        PlayerPrefs.SetInt("God", 1); 
    }

    public static void IncrementCheater()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_cheater, 1, null);
        //TODO Check if achievement unlocked and unlock skin "Filthy"
    }
    public static void UnlockPlayingItSafe()
    {
        Social.ReportProgress(GPGSIds.achievement_playing_it_safe, 100f, null);
        PlayerPrefs.SetInt("Medic", 1);
    }

    public static void IncreaseDeathIsYourFriend()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_death_is_your_friend, 1, null);
        //check if gotten achievement
    }

    public static void IncreaseMemeLee(int num)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_mem_lee, num, null);
    }

    public static void UnlockTheatre()
    {
        Social.ReportProgress(GPGSIds.achievement_theatre_connoisseur, 100f, null);
    }

    public static void UnlockLevel2()
    {
        Social.ReportProgress(GPGSIds.achievement_out_of_the_woods, 100f, null);
        PlayerPrefs.SetInt(IDs.passedLevel1, 1);
    }
    
    public static void UnlockLevel3()
    {
        Social.ReportProgress(GPGSIds.achievement_concrete_jungle, 100f, null);
        PlayerPrefs.SetInt(IDs.passedLevel2, 1);
    }
    public static void UnlockLevel4()
    {
        Social.ReportProgress(GPGSIds.achievement_onto_the_fire, 100f, null);
        PlayerPrefs.SetInt(IDs.passedLevel3, 1);
    }

    public static void BeatGame()
    {
        Social.ReportProgress(GPGSIds.achievement_i_am_hell_incarnate, 100f, null);
        //PlayerPrefs.SetInt(IDs.hasSkin + x, 1);       //Should probably give them a skin for this
    }

    public static void UnlockWhoNeedsDoubleJump()
    {
        Social.ReportProgress(GPGSIds.achievement_who_needs_double_jump_anyways, 100f, null);
        //PlayerPrefs.SetInt(IDs.hasSkin + x, 1);      //Triple jump skin maybe 
    }


    public static void DisplayAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
}
