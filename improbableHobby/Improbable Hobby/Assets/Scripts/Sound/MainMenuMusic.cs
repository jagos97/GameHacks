using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public static AudioSource mainMenuMusic;


    public static bool PlaySong()
    {
        if (mainMenuMusic == null) { 
            mainMenuMusic = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
            mainMenuMusic.Play();
            return true;
        }
        return false;
    }

}

