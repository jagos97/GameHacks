using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffInvisibility : MonoBehaviour
{
    private DebuffManager manager;

    void Start()
    {
        manager = FindObjectOfType<DebuffManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Settings.Vibration) //vibrate if setting is on
                Handheld.Vibrate();

            manager.decreasePlayerOpacity();
            GameTracker.GotADebuff();
        }
    }
}
