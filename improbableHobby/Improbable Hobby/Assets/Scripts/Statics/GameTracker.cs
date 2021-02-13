using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * We can also use prefabs to calculate total lifetime stats and use those for the achievments as well
 */
public static class GameTracker 
{

    //Debuff levels // we need to make functions that can set debuff at certain level at start or should they reset????
    private static int blackDebuffLevel;
    private static int messagesDebuffLevel;
    private static int cameraDebuffLevel;
    private static int jumpDebuffLevel;
    private static int gravityDebuffLevel;
    private static int invisibilityDebuffLevel;


    //Other stats can be used for Achievements as well
    private static float score;
    private static float distance;
    private static int currentLevel = 1;
    private static DeviceOrientation currentDeviceOrientation;

    //stats for which level they have successfully beat
    private static bool beatLevel1;
    private static bool beatLevel2;
    private static bool beatLevel3;
    private static bool beatLevel4;




    //Getters and setter for the variables 
    public static int BlackDebuffLevel { get => blackDebuffLevel; set => blackDebuffLevel = value; }
    public static int MessagesDebuffLevel { get => messagesDebuffLevel; set => messagesDebuffLevel = value; }
    public static int CameraDebuffLevel { get => cameraDebuffLevel; set => cameraDebuffLevel = value; }
    public static int JumpDebuffLevel { get => jumpDebuffLevel; set => jumpDebuffLevel = value; }
    public static int GravityDebuffLevel { get => gravityDebuffLevel; set => gravityDebuffLevel = value; }
    public static int InvisibilityDebuffLevel { get => invisibilityDebuffLevel; set => invisibilityDebuffLevel = value; }
    public static float Score { get => score; set => score = value; }
    public static float Distance { get => distance; set => distance = value; }
    public static int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public static bool BeatLevel1 { get => beatLevel1; set => beatLevel1 = value; }
    public static bool BeatLevel2 { get => beatLevel2; set => beatLevel2 = value; }
    public static bool BeatLevel3 { get => beatLevel3; set => beatLevel3 = value; }
    public static bool BeatLevel4 { get => beatLevel4; set => beatLevel4 = value; }
    public static DeviceOrientation CurrentDeviceOrientation { get => currentDeviceOrientation; set => currentDeviceOrientation = value; }



    //Achievements
    public static bool gotdebuff = false;
    private static bool getNoDebuffAchievement = false;
    public static int level4debuffs = 0;
    public static int punchKills;
    public static int jumpKills;

    public static void GotADebuff()
    {
        if (!gotdebuff && score >= 2000)
        {
            getNoDebuffAchievement = true;
            Debug.Log("Got a debuff after 1000");
        }
        gotdebuff = true;
    }

    public static void IncrementLevel4Debuffs()
    {
        level4debuffs++;
    }


    //I wonder what this function does
    //I think it restarts the game :thinkingEmoji:
    public static void AddToScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    //hmmmmm another mystery never to be solved
    //Why didn't they teach this in school?
    public static void AddToDistance(float distanceToAdd)
    {
        distance += distanceToAdd;
    }

    //curiouser and curiouser (think thats how you spell it
    //Is this chemistry????!?!?!?
    public static void IncrementScreenFlippedAmount()
    {
        Achievements.IncrementCheater();   
    }

    //Guess we'll never know
    //is this even legal?
    public static void IncreaseLevel()
    {
        currentLevel++;
    }

    
    public static void CheckAchievements()
    {

        if (getNoDebuffAchievement || (score >= 1000 && !gotdebuff))            ////Playing it Safe Achievement
        {
            Debug.Log("Should Unlock playing it safe");
            Achievements.UnlockPlayingItSafe();
        }

        Achievements.IncreaseMemeLee(GameTracker.punchKills);            ////M'eme Lee achievement

        if(PlayerPrefs.GetInt(IDs.hasSkin+ 0, 0) == 1)
        {
            if (score >= 5000) Achievements.UnlockWhoNeedsDoubleJump();
        }


        /////////////LEVEL ACHIEVEMENTS
        if (currentLevel == 1 && score >= 8000) Achievements.UnlockLevel2();
        else if (currentLevel == 2 && score >= 10000) Achievements.UnlockLevel3();
        else if (currentLevel == 3 && score >= 12000) Achievements.UnlockLevel4();
        else if (currentLevel == 4 && score >= 15000) Achievements.BeatGame();

    }

    public static void ChangeCurrentOrientation()
    {
        if(currentDeviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            currentDeviceOrientation = DeviceOrientation.LandscapeRight;
        }
        else
        {
            currentDeviceOrientation = DeviceOrientation.LandscapeRight;
        }
    }

    /*
     * Resets game stats to 0 
     */
    public static void ResetStats()
    {
        Score = 0;
        Distance = 0;
        level4debuffs = 0;
        gotdebuff = false;
        getNoDebuffAchievement = false;
        punchKills = 0;
        jumpKills = 0;

    }

    /*
     * Resets the debuff to level 0. Does Not affect actual game tho just in the GameTracker
     */
    public static void ResetDebuffs()
    {
        BlackDebuffLevel = 0;
        JumpDebuffLevel = 0;
        CameraDebuffLevel = 0;
        GravityDebuffLevel = 0;
        MessagesDebuffLevel = 0;
        InvisibilityDebuffLevel = 0;
    }

    /**
     * Resets the stats and Debuffs no actual affect on current gameplay
     */
    public static void CompleteReset()
    {
        ResetStats();
        ResetDebuffs();
    }

}
