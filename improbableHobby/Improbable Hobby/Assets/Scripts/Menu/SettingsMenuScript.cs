using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using GooglePlayGames;

public class SettingsMenuScript : MonoBehaviour
{
    public string back;
    public string aboutUs;
    public string howToPlay;
    public string credits;

    private GameObject vibrationSetting;
    private GameObject autoLevelSwitchSetting;

    private Slider effectsVolume;
    private Slider musicVolume;

    public AudioMixer mainMixer;

    public void Start() //set so when settings is opened, it reads in the stored settings, and sets the buttons accordingly
    {
        Settings.LoadSettingsFromPlayerPrefs();

        Debug.Log(Settings.Vibration);
        Debug.Log(Settings.AutomaticLevelSwitch);
        Debug.Log(Settings.SoundEffects);
        Debug.Log(Settings.MusicSound);
        vibrationSetting = GameObject.Find("VibrationToggle");
        vibrationSetting.GetComponent<Toggle>().isOn = Settings.Vibration;
        autoLevelSwitchSetting = GameObject.Find("EndlessModeLevelAutoTransitionToggle");
        autoLevelSwitchSetting.GetComponent<Toggle>().isOn = Settings.AutomaticLevelSwitch;
        effectsVolume = GameObject.Find("SoundEffectsVolume").GetComponent<Slider>();
        musicVolume = GameObject.Find("MusicVolume").GetComponent<Slider>();
        effectsVolume.value = Settings.SoundEffects;
        musicVolume.value = Settings.MusicSound;

    }

    public void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Escape))    //if back arrow is pushed on Android, go back
            {
                GoBack();

                return;
            }
        }
    }

    public void SetVibrate(bool status)
    {
        Settings.Vibration = status;
        Settings.SetBool("Vibration", status);
        if (status)
        {
            Handheld.Vibrate(); //vibrate when the push enabled
            Debug.Log("VIBRATE IS ON = " + Settings.Vibration);
        }
        else
        {
            Debug.Log("VIBRATE = " + Settings.Vibration);
        }
    }

    public void SetAutoEndlessSwitch(bool status)
    {
        Settings.AutomaticLevelSwitch = status;
        Settings.SetBool("AutomaticLevelSwitch", status);
        PlayerPrefs.Save();
        Debug.Log("AUTO SWITCH ON = " + Settings.AutomaticLevelSwitch);

    }

    public void SetSoundEffectsVolume(float volume)
    {
        mainMixer.SetFloat("EffectsVolume", volume);
        Settings.SoundEffects = volume;
        PlayerPrefs.SetFloat("SoundEffects", volume);
        Debug.Log("SOUND EFFECTS VOLUME: " + volume);
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MusicVolume", volume);
        Settings.MusicSound = volume;
        PlayerPrefs.SetFloat("Music", volume);
        Debug.Log("MUSIC VOLUME: " + volume);
    }


    public void GoAboutUs()
    {
        SceneManager.LoadScene(aboutUs);
    }

    public void GoHowToPlay()
    {
        SceneManager.LoadScene(howToPlay);
    }

    public void GoCredits()
    {
        SceneManager.LoadScene(credits);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(back);
    }
}
