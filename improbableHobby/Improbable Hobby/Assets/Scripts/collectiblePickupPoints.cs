using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblePickupPoints : MonoBehaviour
{

    public int standardScoreBonus;

    private Score scoreManager;
    private AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<Score>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            scoreManager.addToScore(standardScoreBonus);
            gameObject.SetActive(false);
            if (gameObject.name.StartsWith("coin"))
            {
                coinSound.Play();
            }
        }
    }
}
