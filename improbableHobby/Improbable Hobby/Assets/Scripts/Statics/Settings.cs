using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//maybe we should store all of these in PlayerPrefs so that
//the player doesn't need to reset these when the start the game up again
//Yeah probably better just scratch this class then
public static class Settings
{
    private static bool automaticLevelSwitch = true;

    private static float musicSound = 1;
    private static float soundEffects = 1;

    private static bool vibrationOn = true;

    public static bool AutomaticLevelSwitch { get => automaticLevelSwitch; set => automaticLevelSwitch = value; }
    public static float MusicSound { get => musicSound; set => musicSound = value; }
    public static float SoundEffects { get => soundEffects; set => soundEffects = value; }
    public static bool Vibration { get => vibrationOn; set => vibrationOn = value; }




    /*
     * This function will load the settings from the playerPrefs should be called on game start up
     * If playerPrefs haven't been set then it will set them to the default values
     * The keys for the settings are 
     * "AutomaticLevelSwitch" int (1 = true 0 = false)
     * "SoundEffects" float
     * "Music"  float
     * "Vibration" int (1 = true 0 = false)
     */
    public static void LoadSettingsFromPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("AutomaticLevelSwitch"))
        {
            PlayerPrefs.SetInt("AutomaticLevelSwitch", 1);
        }
        AutomaticLevelSwitch = GetBool("AutomaticLevelSwitch");

        if (!PlayerPrefs.HasKey("SoundEffects"))
            PlayerPrefs.SetFloat("SoundEffects", 1);
        SoundEffects = PlayerPrefs.GetFloat("SoundEffects");

        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetFloat("Music", 1);
        MusicSound = PlayerPrefs.GetFloat("Music");

        if (!PlayerPrefs.HasKey("Vibration"))
            PlayerPrefs.SetInt("Vibration", 1);
        Vibration = GetBool("Vibration");
        
    }


    /*
     * Converts ints to bools
     */
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);

        if (value == 1)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public static void SetBool(string key, bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt(key, 1);
        }

        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }
}
