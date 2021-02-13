using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    public GameObject destructionPoint;
    public Pooler pool;
    private Score scoreManager;
    private AudioSource coinSound;
    public int standardScoreBonus;

    // Start is called before the first frame update
    void Start()
    {
        destructionPoint = GameObject.Find("Destruction Point");
        pool = GameObject.Find("CoinPool").GetComponent<Pooler>();
        scoreManager = FindObjectOfType<Score>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destructionPoint.transform.position.x)
        {

            pool.deactivateObject(gameObject);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            scoreManager.addToScore(standardScoreBonus);
            pool.deactivateObject(gameObject);
            coinSound.Play();
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
            
        }
    }

}
