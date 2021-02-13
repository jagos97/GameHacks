using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffGravity : MonoBehaviour
{

    private DebuffManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DebuffManager>();
    }

    // Update is called once per fra

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            if (Settings.Vibration) //vibrate if setting is on
                Handheld.Vibrate();

        manager.increaseGravityLevel();
        GameTracker.GotADebuff();
        }
    }
}
