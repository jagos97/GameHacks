using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("Music"));
        Debug.Log(Settings.GetBool("Vibration"));
        Debug.Log(PlayerPrefs.GetFloat("SoundEffects"));
        Debug.Log(Settings.GetBool("AutomaticLevelSwitch"));
        Settings.LoadSettingsFromPlayerPrefs();
        Debug.Log(Settings.Vibration);
        Debug.Log(Settings.AutomaticLevelSwitch);
        Debug.Log(Settings.SoundEffects);
        Debug.Log(Settings.MusicSound);

        AdManager.RequestInterstital();
        AdManager.RequestReward();

        //start off with skin 0 and 1 unlocked
        PlayerPrefs.SetInt(IDs.hasSkin + 0, 1);
        PlayerPrefs.SetInt(IDs.hasSkin + 1, 1);
        DebuffMessages.SetMessages();


    }


}
