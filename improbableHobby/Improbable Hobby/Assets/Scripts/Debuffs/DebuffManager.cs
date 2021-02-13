using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffManager : MonoBehaviour
{

    public GameObject ManagerOfGame;
    private GameManager gameManager;
    private int skinId;
    private bool done;

    public GameObject scoreKeeper;
    private Score score;

    //Black screen debuff variables 
    private int blackLevel;
    public float durationInSeconds = 0.0f;
    public float timeBetweenInSeconds = 5.5f;
    private bool blackActive = false;
    public GameObject blackScreen;
    public Text blackAmount;


    //Camera debuff variables
    private int cameraLevel;
    public GameObject cameraObject;
    private CameraMovement camera;
    public Text cameraAmount;

    //Debuff Messages variable
    public Text debuffMessage;
    public GameObject textObject;
    private int messageLevel;
    public float durationOfMessage;
    public float timeBetweenMessages;
    public GameObject messageObject;
    //private DebuffMessages debuffMessages;
    public Text messageAmount;
    public GameObject[] points;
    public GameObject messageSprite;
    public GameObject messageSprite2;
    public Text messageText;
    public Text messageText2;
    public GameObject testPoint;
    private int pointTaken = 100;



    //Invisible character debuff variables
    private float opacity = 1f;
    private int opacityLevel;
    private float opacityMultiplier = 0.25f;
    public Text invisibilityAmount;
    public GameObject radioactive;

    //Jump button debuff variables
    private int buttonLevel = 0;
    private Button jumpButton;
    private float buttonScale = 1;
    private float buttonInitialX;
    private float buttonInitialY;
    private Vector3 screenDimensions;
    public Text jumpAmount;
    private Vector3 leftJumpButtonPoint;
    private Vector3 rightJumpButtonPoint;
    private bool buttonIsOnRightSide;   //true = Right side, false = Left Side

    //Gravity debuff variables
    public int gravityLevel;
    public GameObject player;
    private Rigidbody2D playerBody;
    public Text gravityAmount;



    void Awake()
    {
        gameManager = ManagerOfGame.GetComponent<GameManager>();
        score = scoreKeeper.GetComponent<Score>();
        camera = cameraObject.GetComponent<CameraMovement>();
        //debuffMessages = messageObject.GetComponent<DebuffMessages>();
        playerBody = player.GetComponent<Rigidbody2D>();
        skinId = PlayerPrefs.GetInt("SkinID");
        jumpButton = gameManager.jumpButton;
        //buttonInitialX = jumpButton.image.rectTransform.localPosition.x;
        //buttonInitialY = jumpButton.image.rectTransform.localPosition.y;
        leftJumpButtonPoint = gameManager.leftButtonPoint.rectTransform.localPosition;
        rightJumpButtonPoint = gameManager.rightButtonPoint.rectTransform.localPosition;
        gameManager.player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        gravityAmount = GameObject.Find("Gravity Text").GetComponent<Text>();
        jumpAmount = GameObject.Find("Jump Text").GetComponent<Text>();
        invisibilityAmount = GameObject.Find("Invisibility Text").GetComponent<Text>();
        messageAmount = GameObject.Find("Message Text").GetComponent<Text>();
        cameraAmount = GameObject.Find("Camera Text").GetComponent<Text>();
        blackAmount = GameObject.Find("Black Text").GetComponent<Text>();
        buttonIsOnRightSide = true;
        Debug.Log(blackAmount.text);
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// /////////////////////////////////// Invisible Player Debuff
    /// </summary>
    ///

        //alter so level 4 isn't constant invisiblity but flashing back and forth
    public void decreasePlayerOpacity()
    {
        if(opacityLevel < 4)  //we only want to be between 0f and 1f (1f is fully
        {
            opacityLevel += 1;
            GameTracker.gotdebuff = true;
            GameTracker.InvisibilityDebuffLevel += 1;
            score.addToMultiplier();
            invisibilityAmount.text = "x" + opacityLevel;
            if (opacityLevel < 4)
            {
                opacity -= opacityMultiplier;
            }
            else
            {
                GameTracker.level4debuffs += 1;
                if(GameTracker.level4debuffs == 6)
                {
                    if (!done)
                    {
                        done = true;
                        StartCoroutine(StartGodModeTest());
                    }
                }
                StartCoroutine(SwitchOpacityTimer());
            }

            Color color = new Color(1f, 1f, 1f, opacity);
            gameManager.player.GetComponent<SpriteRenderer>().color = color;
        }
    }

    //im assuming it goes level 0 for none, then level 1, 2, 3, 4?
    public void SetInvisibilityToLevel(int level)
    {
        opacityLevel = level;
        opacity -= opacityMultiplier * level;
        if(opacity == 0)
        {
            opacity += opacityMultiplier;
        }
        invisibilityAmount.text = "x" + opacityLevel;
        for (int i = 0; i < level; i++)
        {
            score.addToMultiplier();
        }
        Color color = new Color(1f, 1f, 1f, opacity);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = color;
        if(level == 4)
        {
            StartCoroutine(SwitchOpacityTimer());
        }
    }


    //Please don't use this function
    /*
    private void SetInvisibilityToLevelWithoutAffectingText(int level)
    {
        opacityLevel = level;
        for (int i = 0; i < level; i++)
        {
            score.addToMultiplier();
        }
        Color color = new Color(1f, 1f, 1f, 1f - (opacityMultiplier * level));

        gameManager.player.GetComponent<SpriteRenderer>().color = color;
    }
    */

    private IEnumerator SwitchOpacityTimer()
    {
        if(gameManager.alive)
        {
            yield return new WaitForSeconds(2); //testing switch every 2 seconds

            SetInvisibility(true);

            yield return new WaitForSeconds(2);

            SetInvisibility(false);  //invisible
            

            StartCoroutine(SwitchOpacityTimer());
        }
    }

    
    private void SetInvisibility(bool invisible)
    {
        player.GetComponent<SpriteRenderer>().enabled = invisible;
        
    }

    /// <summary>
    /// /////////////////////////////////// Jump Button Debuff
    /// </summary>
    ///

    /*
     * Level 4 = Button flips between right and left and only appears right before the platform ends
     */
    public void increaseButtonLevel()
    {

        jumpButton = gameManager.jumpButton;

        if (buttonLevel < 4)
        {
            buttonLevel += 1;
            GameTracker.gotdebuff = true;
            GameTracker.JumpDebuffLevel += 1;
            score.addToMultiplier();
            jumpAmount.text = "x" + buttonLevel;           

            if (buttonLevel == 1 || buttonLevel == 2)
            {
                Debug.Log("In proper method!");
                buttonScale = (float)(buttonScale * 0.7);
                jumpButton.image.rectTransform.localScale = new Vector3(buttonScale, buttonScale, 1);
            }
            else if(buttonLevel == 3)
            {
                switchButtonSideToLeft();
            }
            else if(buttonLevel == 4)
            {
                GameTracker.level4debuffs += 1;
                if (GameTracker.level4debuffs == 6)
                {
                    if (!done)
                    {
                        done = true;
                        StartCoroutine(StartGodModeTest());
                    }
                }
                StartCoroutine(switchButtonSideContinuous());
            }
        }
    }

    public void SetJumpButtonToLevel(int level)
    {
        jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        buttonLevel = level;
        jumpAmount.text = "x" + buttonLevel;
        if (buttonLevel >= 1)
        {
            buttonScale = (float)(buttonScale * 0.7);
            jumpButton.image.rectTransform.localScale = new Vector3(buttonScale, buttonScale, 1);
        }
        if (buttonLevel >= 2)
        {
            buttonScale = (float)(buttonScale * 0.7);
            jumpButton.image.rectTransform.localScale = new Vector3(buttonScale, buttonScale, 1);
        }
        if (buttonLevel >= 3)
        {
            switchButtonSideToLeft();
        }
        if (buttonLevel == 4)
        {
            StartCoroutine(switchButtonSideContinuous());
        }

        for (int i = 0; i < level; i++)
        {
            score.addToMultiplier();
        }
    }

        private void switchButtonSideToLeft()
    {
        jumpButton = gameManager.jumpButton;
        leftJumpButtonPoint = gameManager.leftButtonPoint.rectTransform.localPosition;

        jumpButton.transform.localPosition = new Vector3(leftJumpButtonPoint.x + (float)((buttonScale) * DebuffJumpButton.defaultWidth), leftJumpButtonPoint.y);
    }

    private void switchButtonSideToRight()
    {
        jumpButton = gameManager.jumpButton;
        rightJumpButtonPoint = gameManager.rightButtonPoint.rectTransform.localPosition;

        jumpButton.transform.localPosition = new Vector3(rightJumpButtonPoint.x, rightJumpButtonPoint.y);
    }

    //for now, I switch buttons every few seconds
    private IEnumerator switchButtonSideContinuous()
    {
        if(gameManager.alive)   //only run while the player is alive
        {
            yield return new WaitForSeconds(3);

            buttonIsOnRightSide = !buttonIsOnRightSide; //flips boolean to opposite value

            Debug.Log("BUTTON ON RIGHT? = " + buttonIsOnRightSide);

            if (buttonIsOnRightSide) //if button needs to be moved from left side (current side) to right side
            {
                switchButtonSideToRight();
            }
            else   //if button needs to be moved from right side (current side) to left
            {
                switchButtonSideToLeft();
            }

            StartCoroutine(switchButtonSideContinuous());
        }
    }

    /// <summary>
    /// /////////////////////////////////// Black Screen Debuff
    /// </summary>
    ///

    public void increaseBlackLevel()
    {
        if (blackLevel < 4)
        {
            blackLevel += 1;
            if (blackLevel == 1)
            {
                StartCoroutine(waitBlack());
            }
            GameTracker.gotdebuff = true;
            GameTracker.BlackDebuffLevel += 1;
            durationInSeconds += 0.4f;
            timeBetweenInSeconds -= 0.5f;
            score.addToMultiplier();
            blackAmount.text = "x" + blackLevel;
            if(blackLevel == 4)
            {
                GameTracker.level4debuffs += 1;
                if (GameTracker.level4debuffs == 6)
                {
                    if (!done)
                    {
                        done = true;
                        StartCoroutine(StartGodModeTest());
                    }
                }
            }

        }

    }


    private IEnumerator waitBlack()
    {
        if (blackLevel > 0)
        {
            yield return new WaitForSeconds(timeBetweenInSeconds);
            if (blackLevel > 0 && gameManager.alive)
            {
                blackActive = true;
                blackScreen.SetActive(true);
                StartCoroutine(activateBlack());
            }
        }
    }

    private IEnumerator activateBlack()
    {
            yield return new WaitForSeconds(durationInSeconds);
            blackActive = false;
            blackScreen.SetActive(false);
            if (blackLevel > 0)
            {
                StartCoroutine(waitBlack());
            }
        
    }

    /**
     * Assumes it to be starting from 0
     */
    public void SetBlackDebuffToLevel(int level)
    {
        blackLevel = level;
        durationInSeconds += 0.4f * (float)level;
        timeBetweenInSeconds -= 0.5f * (float)level;
        blackAmount.text = "x" + blackLevel;
        for (int i =0; i <  level; i++)
        {
            score.addToMultiplier();
        }
        if(blackLevel >= 1)
            StartCoroutine(waitBlack());
    }


    /// <summary>
    /// ///////////////////////////////////Camera Debuff
    /// </summary>
    public void increaseCameraLevel()
    {
        if (cameraLevel < 4)
        {
            cameraLevel += 1;
            GameTracker.gotdebuff = true;
            GameTracker.CameraDebuffLevel += 1;
            camera.addDebuffLevel();
            score.addToMultiplier();
            cameraAmount.text = "x" + cameraLevel;

            if (cameraLevel == 3)
            {
                gameManager.DetectScreenChange();
                GameTracker.CurrentDeviceOrientation = Input.deviceOrientation;
                camera.flipCamera();
            }

            else if (cameraLevel == 4)
            {
                camera.startAssholeCamera();
                GameTracker.level4debuffs += 1;
                if (GameTracker.level4debuffs == 6)
                {
                    if (!done)
                    {
                        done = true;
                        StartCoroutine(StartGodModeTest());
                    }
                }
            }
        }
    }

   /**
   * Assumes it to be starting from 0
   */
    public void SetCameraToLevel(int level)
    {
        cameraLevel = level;
        cameraAmount.text = "x" + cameraLevel;
        for (int i = 0; i < level; i++)
        {
            camera.addDebuffLevel();
            score.addToMultiplier();
        }
        if (cameraLevel == 3)
            camera.flipCamera();
        else if (cameraLevel == 4)
            camera.startAssholeCamera();
    }

    /// <summary>
    /// ///////////////////////////////////Message Debuff
    /// </summary>

    public void increaseMessageLevel()
    {
        if(messageLevel < 4)
        {
            messageLevel += 1;
            GameTracker.gotdebuff = true;
            GameTracker.MessagesDebuffLevel += 1;
            durationOfMessage += 2.0f;
            timeBetweenMessages -= 2.0f;
            score.addToMultiplier();
            messageAmount.text = "x" + messageLevel;
            if(messageLevel == 1)
            {
                StartCoroutine(showMessage());
            }
            if(messageLevel == 4)
            {
                GameTracker.level4debuffs += 1;
                if (GameTracker.level4debuffs == 6)
                {
                    if (!done)
                    {
                        done = true;
                        StartCoroutine(StartGodModeTest());
                    }
                }
                StartCoroutine(showMessage2());
            }
            
        }
    }

    /**
    * Assumes it to be starting from 0
    */
    public void SetMessageToLevel(int level)
    {
        messageLevel = level;
        durationOfMessage += 2.0f * (float)level;
        timeBetweenMessages -= 2.0f * (float)level;
        messageAmount.text = "x" + messageLevel;
        for (int i = 0; i < level; i++)
        {
            score.addToMultiplier();
        }
        if(messageLevel >= 1)
            StartCoroutine("showMessage");
        if (messageLevel == 4)
            StartCoroutine("showMessage2");

    }


    private IEnumerator showMessage()
    {
        if (messageLevel > 0)
        {
            int rand = UnityEngine.Random.Range(0,points.Length);
            while(rand == pointTaken)
            {
                rand = UnityEngine.Random.Range(0, points.Length);
            }
            pointTaken = rand;
            RectTransform newPos = points[rand].GetComponent<RectTransform>();
            messageSprite.GetComponent<RectTransform>().localPosition = newPos.localPosition;
            messageSprite.SetActive(true);
            messageText.text = DebuffMessages.getMessageFromLevel(GameTracker.CurrentLevel);
            yield return new WaitForSeconds(timeBetweenMessages);
            StartCoroutine(hideMessage());
        }

    }

    private IEnumerator hideMessage()
    {
        messageSprite.SetActive(false);
        yield return new WaitForSeconds(timeBetweenMessages);
        if(messageLevel > 0)
        {
            StartCoroutine(showMessage());
        }
    }


    private IEnumerator showMessage2()
    {
        if (messageLevel > 0)
        {
            int rand = UnityEngine.Random.Range(0, points.Length);
            while (rand == pointTaken)
            {
                rand = UnityEngine.Random.Range(0, points.Length);
            }
            pointTaken = rand;
            RectTransform newPos = points[rand].GetComponent<RectTransform>();
            messageSprite2.GetComponent<RectTransform>().localPosition = newPos.localPosition;
            messageSprite2.SetActive(true);
            messageText2.text = DebuffMessages.getMessageFromLevel(GameTracker.CurrentLevel);
            yield return new WaitForSeconds(timeBetweenMessages);
            StartCoroutine(hideMessage2());
        }

    }

    private IEnumerator hideMessage2()
    {
        messageSprite2.SetActive(false);
        yield return new WaitForSeconds(timeBetweenMessages);
        if (messageLevel > 0)
        {
            StartCoroutine(showMessage2());
        }
    }



    public void gameOverDisableMessage()
    {
        messageSprite.SetActive(false);
    }



    /// <summary>
    /// /////////////////////////////////// Gravity Debuff
    /// </summary>
    /// 

    public void increaseGravityLevel()
    {
        if (gravityLevel < 4)
        {
            gravityLevel += 1;
            GameTracker.gotdebuff = true;
            GameTracker.GravityDebuffLevel += 1;
            playerBody.gravityScale += 0.1f;
            score.addToMultiplier();
            gravityAmount.text = "x" + gravityLevel;
            if(gravityLevel == 4)
            {
                GameTracker.level4debuffs += 1;
                if (GameTracker.level4debuffs == 6)
                {
                    if (!done)
                    {
                        done = true;
                        StartCoroutine(StartGodModeTest());
                    }
                }
            }
        }
    }
    /**
* Assumes it to be starting from 0
*/
    public void setGravityToLevel(int level)
    {
        gravityLevel = level;
        
        GameObject.Find("Player").GetComponent<Rigidbody2D>().gravityScale += 0.1f *(float) level;
        gravityAmount.text = "x" + gravityLevel;
        for (int i = 0; i < level; i++)
        {
            score.addToMultiplier();
        }
    }


    /**
     * Resets the debuffs back to level 1. Does NOT Change it in the GameTracker
     */
    public void Reset()
    {
        // resets black screen debuff
        blackLevel = 0;
        durationInSeconds = 0.0f;
        timeBetweenInSeconds = 5.5f;
        blackScreen.SetActive(false);
        blackActive = false;
        blackAmount.text = "x0";

        //Reset camera Debuff
        if (cameraLevel >= 3)
        {
            camera.flipCamera();
        }
        cameraLevel = 0;
        camera.ResetDebuffLevel();
        cameraAmount.text = "x0";


        //Reset Messages debuff
        messageSprite.SetActive(false);
        messageLevel = 0;
        messageSprite2.SetActive(false);
        durationOfMessage = 0.0f;
        timeBetweenMessages = 15.0f;
        messageAmount.text = "x0";

        //resets opacity debuff
        opacityLevel = 0;
        opacity = 1f;
        opacityMultiplier = 0.25f;
        player.GetComponent<SpriteRenderer>().enabled = true;
        gameManager.player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        invisibilityAmount.text = "x0";
        


        //reset jump button
        buttonLevel = 0;
        buttonScale = 1;
        jumpButton = gameManager.jumpButton;
        jumpButton.transform.localPosition = DebuffJumpButton.jumpButtonPositionDefaults;   //set back to proper right side position
        jumpButton.transform.localScale = new Vector3(buttonScale, buttonScale, buttonScale); //scale properly resets
        jumpAmount.text = "x0";
        buttonIsOnRightSide = true;
        


        //Reset Gravity
        gravityLevel = 0;
        playerBody.gravityScale = 1;
        gravityAmount.text = "x0";


        StopAllCoroutines(); //probably should have added this a while ago
    }

    private IEnumerator StartGodModeTest()      ////God Mode Achievement
    {
        Debug.Log("Started god mode timer");
        yield return new WaitForSeconds(60);
        Debug.Log("finished god mode timer");

        Achievements.UnlockGodMode();         
    }

    public void StopGodModeTest()
    {
        Debug.Log("stopping god mode timer");

        StopCoroutine(StartGodModeTest());
    }



}
