using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{

    public List<AudioClip> deathSounds;
    public AudioClip soliloquy;
    private bool getAchievement = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = deathSounds[Random.Range(0, deathSounds.Count)];
        if(Random.Range(0,20) == 1)
        {
            gameObject.GetComponent<AudioSource>().clip = soliloquy;
            getAchievement = true;
        }
    }

    public void Reset()
    {
        gameObject.GetComponent<AudioSource>().clip = deathSounds[Random.Range(0, deathSounds.Count)];
        getAchievement = false;
        if (Random.Range(0, 20) == 1)
        {
            gameObject.GetComponent<AudioSource>().clip = soliloquy;
            getAchievement = true;
        }
        StopTimer();
    }

    /**
     *Timer for the theatre achievement
     */
    public void checkTimer()
    {
        if (getAchievement)
        {
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        Debug.Log("Starting timer for the soliloquy");
        yield return new WaitForSeconds(120f);
        Debug.Log("finished timer for the soliloquy");
        Achievements.UnlockTheatre();
    }

    public void StopTimer()
    {
        Debug.Log("Stpoing timer for the soliloquy");
        StopAllCoroutines();
    }

}
