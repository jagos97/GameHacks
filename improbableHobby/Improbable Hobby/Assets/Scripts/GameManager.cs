using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This class manages death, score and in the future, restarting the level and other things like that
//I can already see this becoming graphics repainter
//RIP
public class GameManager : MonoBehaviour
{
    public GameObject scoreManager;
    public Score score;

    public GameObject player;
    private Vector3 startPoint;

    public GameObject platformPooler;
    private Pooler platformPool;

    public GameObject coinPooler;
    private Pooler coinPool;

    public GameObject debuffPooler;
    private Pooler debuffPool;

    public GameObject platformGenerator;
    private GeneratePlatforms platformGeneration;

    public int winCondition;
    
    public GameObject winSprite;
    public GameObject gameOverCanvas;

    private int multiplier;
    public bool alive = true;

    public GameObject ManagerOfDebuffs;
    private DebuffManager debuffManager;

    private InputListener inputListener;

    //private AudioSource deathSound;

    public GameObject followPlayer;
    private Vector3 followPlayerStartPoint;

    public GameObject jumpObject;
    public Button jumpButton;

    public ScrollingBackgroundScript scrollingBackground;

    public Text coinText;

    //Prefab of the winning platform
    public GameObject lastPlatform;

    //used so that the win game function isn't called multiple times
    private bool notDoneYet = true;

    //platform player has to be on to win
    private GameObject winningPlatform;

    public Image leftButtonPoint;
    public Image rightButtonPoint;

    private GameObject pauseButton;

    public Pooler enemyPool;

    private AudioSource deathSound;
    private DeathSounds deathSounds;


    //game stats
    private float distance;     //used to calculate distance 
    private int screenFlippedWhileDebuffActive;
    private GameObject punchButton;

    public Vector3 StartPoint { get => startPoint; set => startPoint = value; }




    void Awake()
    {
        DebuffMessages.SetMessages();
        score = scoreManager.GetComponent<Score>();
        score.scoreCount = GameTracker.Score;
        startPoint = player.transform.position;
        platformPool = platformPooler.GetComponent<Pooler>();
        coinPool = coinPooler.GetComponent<Pooler>();
        debuffPool = debuffPooler.GetComponent<Pooler>();
        platformGeneration = platformGenerator.GetComponent<GeneratePlatforms>();
        debuffManager = ManagerOfDebuffs.GetComponent<DebuffManager>();
        inputListener = player.GetComponent<InputListener>();
        deathSound = GameObject.Find("DeathSounds").GetComponent<AudioSource>();
        deathSounds = GameObject.Find("DeathSounds").GetComponent<DeathSounds>();
        followPlayerStartPoint = followPlayer.transform.position;
        scrollingBackground = followPlayer.GetComponentInChildren<ScrollingBackgroundScript>();
        jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpButton.image.rectTransform.localPosition = DebuffJumpButton.jumpButtonPositionDefaults;
        jumpButton.image.rectTransform.localScale.Set(1, 1, 1);
        pauseButton = GameObject.Find("PauseButton");
        leftButtonPoint = GameObject.Find("leftPoint").GetComponent<Image>();
        rightButtonPoint = GameObject.Find("rightPoint").GetComponent<Image>();



        punchButton = GameObject.Find("PunchButton");
        if (!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        //SetDebuffs();
        Destroy(GameObject.Find("MainMenuMusic"));
        Destroy(GameObject.Find("Load Ad"));
        AdManager.DestroyBanner();
        MenuAds.ad = false;

    }


    // Start is called before the first frame update
    void Start()
    {


    }

    private void SetDebuffs()
    {
        debuffManager.SetBlackDebuffToLevel(GameTracker.BlackDebuffLevel);
        debuffManager.SetCameraToLevel(GameTracker.CameraDebuffLevel);
        debuffManager.setGravityToLevel(GameTracker.GravityDebuffLevel);
        debuffManager.SetMessageToLevel(GameTracker.MessagesDebuffLevel);
        debuffManager.SetInvisibilityToLevel(GameTracker.InvisibilityDebuffLevel);
        debuffManager.SetJumpButtonToLevel(GameTracker.JumpDebuffLevel);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "x" + PlayerPrefs.GetInt("Coin");
        
        /*
        if ((score.scoreCount >= winCondition) && notDoneYet) // what happens when a certain score is reached (starts to switch scene)
        {
            notDoneYet = false;
            if (Settings.AutomaticLevelSwitch)
            {
                SwitchScene();
            }
        }
        */
       

    }

    /*
     * Should be called once camera debuff is level 3 and will start counting screen changes checking every 2 seconds 
     */
    public void DetectScreenChange()
    {
        StartCoroutine(CheckScreenChange());
    }

    private IEnumerator CheckScreenChange()     
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Checking if screen orientation Changed");
        if(Input.deviceOrientation != GameTracker.CurrentDeviceOrientation)
        {
            Achievements.IncrementCheater();
            Debug.Log("ScreenOrientation changed.");

        }
        if (GameTracker.CameraDebuffLevel >= 3)
        {
            StartCoroutine(CheckScreenChange());
        }
    }


    /*
     * Changes the alive status of M'eme. If you change it to dead it sets up the game over screen
     */
    public void setAlive(bool isAlive)
    {
        this.alive = isAlive;
        if (!alive) //if dead
        {
            setInGameStats();
            GameTracker.CheckAchievements();
            Achievements.IncreaseDeathIsYourFriend();
            score.updateHighScore();
            deathSounds.checkTimer();
            score.alive = false;
            debuffManager.StopGodModeTest();
            pauseButton.SetActive(false);
            deathSound.Play();
            punchButton.SetActive(true);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + (int)score.scoreCount / 1000);
            Leaderboards.SubmitScoreToLeaderboard(score.scoreCount);
            punchButton.SetActive(false);
            jumpObject.SetActive(false);
            //debuffManager.gameOverDisableMessage();
            StartCoroutine(AdBreak());
            



        }
    }

    public IEnumerator AdBreak()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        if (UnityEngine.Random.Range(0, 2) == 1) // 50 percent chance of loading ad
        {
            AdManager.DisplayInterstitial();
        }
        gameOverCanvas.SetActive(true);
        GameTracker.CompleteReset();


    }
    private void setInGameStats()
    {
        GameTracker.AddToDistance(player.transform.position.x - startPoint.x);
        GameTracker.Score = score.scoreCount;
       
    }


    /**
     * Sets up the scene when the level is beat and once the scene is set up inputListener sets up the animation
     */
    private void SwitchScene()
    {
        winningPlatform = Instantiate(lastPlatform);
        float xPos = platformGeneration.lastPlatform.transform.position.x  + platformGeneration.lastPlatform.GetComponent<BoxCollider2D>().bounds.size.x / 2.0f + winningPlatform.GetComponent<BoxCollider2D>().bounds.size.x / 2.0f;
        winningPlatform.transform.position = new Vector3(xPos, platformGeneration.transform.position.y, platformGeneration.transform.position.z);
        platformGeneration.startPoint = new Vector3(xPos + 10000, platformGeneration.startPoint.y, platformGeneration.startPoint.z);
        inputListener.winPosition = xPos - winningPlatform.GetComponent<BoxCollider2D>().bounds.size.x / 2.0f + 10.0f;
        inputListener.won = true;
        inputListener.endLevelAnimation();
    }

    /*
     * Loads the next level Scene
     */
    public void changeScene()
    {
        GameTracker.IncreaseLevel();
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + (int)score.scoreCount / 1000);
        GameTracker.CheckAchievements();
        StartCoroutine(AdBreakChangeLevel());

        
    }

    public IEnumerator AdBreakChangeLevel()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        if (UnityEngine.Random.Range(0, 2) == 1) // 33 percent chance of loading ad
        {
            AdManager.DisplayInterstitial();
            yield return new WaitForSecondsRealtime(0.5f);
        }
        setInGameStats();
        SceneManager.LoadScene("Level" + GameTracker.CurrentLevel);


    }



    /*
     * Restarts the game
     */
    public void restartGame()
    {
        score.Reset();
        inputListener.Reset();
        player.transform.position = startPoint;
        platformPool.Reset();
        deathSounds.Reset();
        coinPool.Reset();
        debuffPool.Reset();
        platformGeneration.Reset();
        punchButton.SetActive(true);
        alive = true;
        score.alive = alive;
        gameOverCanvas.SetActive(false);
        debuffManager.Reset();
        followPlayer.transform.position = followPlayerStartPoint;
        scrollingBackground.Reset();
        pauseButton.SetActive(true);
        GameTracker.CompleteReset();
        enemyPool.Reset();
        jumpObject.SetActive(true);
        GameObject.Find("JumpButton").SetActive(true);
        if (inputListener.won) //incase they reach win condition but not the last platform
        {
            Destroy(winningPlatform);
            notDoneYet = true;
        }


    }
}
