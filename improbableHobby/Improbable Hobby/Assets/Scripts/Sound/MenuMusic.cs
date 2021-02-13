using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    AudioSource music;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!MainMenuMusic.PlaySong())
        {
            Destroy(this.gameObject);
        }
        music = GetComponent<AudioSource>();
    }

    void Update()
    {
        music.volume = PlayerPrefs.GetFloat(IDs.musicVolume);
    }

}
