using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{
    private Pooler pool;
    private Score score;
    private AudioSource enemyDeath;

    void Start()
    {
        pool = GameObject.Find("EnemyPool").GetComponent<Pooler>();
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        enemyDeath = GameObject.Find("EnemyDeathSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if touching enemy

        if (collision.gameObject.tag == "Enemy")
        {
            enemyDeath.Play();
            pool.deactivateObject(collision.gameObject);
            score.AddPointsForEnemyKill();
            GameTracker.punchKills += 1;
        }
    }
}
