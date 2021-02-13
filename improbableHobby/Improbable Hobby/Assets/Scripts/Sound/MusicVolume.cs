using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = Settings.MusicSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
