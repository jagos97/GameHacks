using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Text highScoreText;
    public Text multiplierText;

    public int multiplier = 1;

    public float scoreCount;

    public float pointsPerSecond;

    public bool alive;

    public float highScoreCount;
    public int pointsForEnemy = 20;




    // Start is called before the first frame update
    void Start()
    {

        highScoreCount = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            scoreCount += (pointsPerSecond * Time.deltaTime) * multiplier;

            /**
            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                PlayerPrefs.SetFloat("HighScore", highScoreCount);  //saves the high score permanently
            }
            */
        }

        score.text = "Score: " + Mathf.Round(scoreCount);
        //highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }

    public void addToScore(int amount)
    {
        scoreCount += amount * multiplier;
    }

    public void AddPointsForEnemyKill()
    {
        scoreCount += pointsForEnemy * multiplier;
    }

    public void addToMultiplier()
    {
        multiplier += 1;
        multiplierText.text = "x" + multiplier;
    }

    public void Reset()
    {
        multiplier = 1;
        multiplierText.text = "x1";
        scoreCount = 0;
    }

    public void updateHighScore()
    {
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
            highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        }
    }
}
