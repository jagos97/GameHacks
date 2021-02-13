using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffJumpButton : MonoBehaviour
{
    private DebuffManager manager;


    //default x, y and z position
    public static Vector3 jumpButtonPositionDefaults = new Vector3(400, -204, 0);

    public static double defaultWidth = 302.4;
    public static double defaultHeight = 348.8;

    public static double initialScreenOffset;

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

            manager.increaseButtonLevel();
            GameTracker.GotADebuff();
        }
    }

}
