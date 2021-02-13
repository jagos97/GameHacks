using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float jumpForce;     //5 is ideal
    public float enemyBounceForce;
    public float moveSpeed;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool shouldJump;
    public GameObject manager;

    public bool jumpButtonEngaged = false;


    //to be used for current speed. Can change during game
    private float currentSpeed;
    private float currentJumpForce;

    public float fallMultiplier = 2.5f; //used for better jump
    public float lowJumpMultiplier = 2f;

    private int totalJumpsAllowed = 1; //the maximum number of jumps allowed before touching the ground again
    private int jumpCounter;  //2 jumps until you hit the ground again

    private bool touchingGround;
    private bool alive = true;

    private Animator playerAnimator;
    private GameManager gameManager;
    private int skinID;


    public bool won = false;
    public float winPosition;

    private AudioSource jumpSound;
    private AudioSource enemyDeath;

    private bool punching;
    private int punchCounter = 1;
    private float punchForce = 1;
    public GameObject punchingFire;

    private AudioSource punchSound;
    private Pooler enemyPool;

    private bool extraLife;
    private AudioSource reviveSound;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        reviveSound = GameObject.Find("ReviveSound").GetComponent<AudioSource>();
        //bc = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        gameManager = manager.GetComponent<GameManager>();
        jumpTimeCounter = jumpTime;
        Debug.Log("Screen: " + Screen.width + " Camera: " + GameObject.Find("Main Camera").GetComponent<Camera>().pixelWidth);
        currentSpeed = moveSpeed;
        currentJumpForce = jumpForce;
        jumpCounter = totalJumpsAllowed;
        playerAnimator.SetBool("isDead", false);
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        enemyDeath = GameObject.Find("EnemyDeathSound").GetComponent<AudioSource>();
        skinID = PlayerPrefs.GetInt("SkinID");
        playerAnimator.SetInteger("SkinID", skinID);
        punchSound = GameObject.Find("PunchSound").GetComponent<AudioSource>();
        enemyPool = GameObject.Find("EnemyPool").GetComponent<Pooler>();
        if (skinID > 0) // if any skin other than no cape skin
        {
            totalJumpsAllowed = 2;
        }
        if (skinID == 2)
        {
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
        }
        else if (skinID == 3) //radioactive
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        else if (skinID == 4) //medic
        {
            extraLife = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {


    }

   

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(3, rb.velocity.y, 0);
        transform.position += movement * Time.deltaTime * currentSpeed;
        rb.velocity = new Vector2((float)(currentSpeed * 0.8), rb.velocity.y);
        playerAnimator.SetFloat("Speed", rb.velocity.x);

        if (!punching)
        {
            applyGravity();
        }
    }


    /*Once the win condition has been met the game manager will call this function will play the animation to play the game
     * Should not be called by input listener itself
     */
    public void endLevelAnimation()
    {
        StartCoroutine(WinGame());
    }


    /**
     *Will make the player punch if conditions are met
     */
    public void Punch()
    {
        if(punchCounter >0 && !punching) //
        {
            punchSound.Play();
            punchingFire.SetActive(true);
            punchCounter--;
            punching = true;
            currentSpeed += punchForce;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.gravityScale = 0;
            StartCoroutine(PunchRoutine());
        }
    }

    /**
     * Punch routine will slowly speed down m'eme and once it is done m'eme will be able to punch
     */
    private IEnumerator PunchRoutine()
    {
        float percentage = 0.25f;
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.15f);
            currentSpeed -= (float)(punchForce * percentage);
        }
        punching = false;
        currentSpeed = moveSpeed;
        punchingFire.SetActive(false);
        rb.gravityScale = 1 + gameManager.ManagerOfDebuffs.GetComponent<DebuffManager>().gravityLevel * 0.1f;
        yield return new WaitForSeconds(0.5f);
        punchCounter++;
        
        
        
    }
    
    /**
     *starts the animation for the endgame after 6 seconds
     */
    private IEnumerator WinGame()
    {
        Debug.Log("WinGame");
        yield return new WaitForSeconds(6.0f);
        if (gameManager.score.scoreCount >= gameManager.winCondition && gameManager.alive)
        {
            DeactivatePunch();
            if (CameraMovement.Flipped)
            {
                GameObject.Find("Main Camera").GetComponent<CameraMovement>().flipCamera();
            }
            GameObject.Find("JumpButton").SetActive(false);
            GameObject.Find("Main Camera").GetComponent<CameraMovement>().enabled = false;
            GameObject.Find("Backgrounds").GetComponent<ScrollingBackgroundScript>().enabled = false;
            GameObject.Find("Backgrounds").transform.parent = null;
            yield return new WaitForSeconds(CalculateTimeForJump());
            enableJumpButton();
            yield return new WaitForSeconds(0.5f);
            gameManager.changeScene();
            //switch scene
        }
    }

    /**
     * Returns to a state where he is not punching and can no longer punch
     * Made it for the end game animation but if ya need it for anything go for it
     */
    private void DeactivatePunch()
    {
        StopCoroutine(PunchRoutine());
        punchCounter = 0;
        currentSpeed = moveSpeed;
        punchingFire.SetActive(false);
        rb.gravityScale = 1;
    }



    /**
     *Calculates the time it will take m'eme to reach 92% of the screen
     */
    private float CalculateTimeForJump()
    {
        float sizeOfScreen = (float)Screen.width;
        float whereToJump = sizeOfScreen * 0.92f;
        //Debug.Log(rb.velocity.x + " rb velocity" );
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 locationOfJump = cam.ScreenToWorldPoint(new Vector3(whereToJump, 0, 0));
        float distanceFromLocation = locationOfJump.x - transform.position.x;
        float time = distanceFromLocation / (3.0f * currentSpeed + rb.velocity.x); 
        return time;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //if touching ground

        if (collision.gameObject.tag == "Ground")
        {
            if (collision.gameObject.transform.position.y + collision.gameObject.GetComponent<BoxCollider2D>().bounds.size.y /2 < transform.position.y)
            {
                StopCoroutine("StartFlightTimer");
                touchingGround = true;
                playerAnimator.SetBool("Grounded", touchingGround);
                refillJumps();  //when touching the ground, refill jumps
            }
        }
        //if touching something that will kill character
        else if(collision.gameObject.tag == "Enemy")
        {
            bool kill = false;
            foreach(ContactPoint2D point in collision.contacts)
            {
                Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
                if(point.normal.y >= 0.9 || transform.position.x > collision.gameObject.transform.position.x)
                {
                    if (!punching)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, enemyBounceForce);
                        gameManager.score.AddPointsForEnemyKill();
                        enemyPool.deactivateObject(collision.gameObject);
                        GameTracker.jumpKills += 1;
                    }
                    refillJumps();
                    kill = true;
                    enemyDeath.Play();
                    break;

                }
            }
            if(!kill)
            {
                if (!punching)
                    Die();
            }
        }
        else if (collision.gameObject.tag == "Death")
        {   //tag used to kill player
            Die();

        }
    }
        
        /*
        else if (collision.gameObject.tag == "DeathGround")
        {
            gameManager.setAlive(false);

        }
        */

    /**
     *kills m'eme
     */
    private void Die()
    {
        if (!extraLife)
        {
            jumpCounter = 0;
            currentSpeed = 0;
            currentJumpForce = 0;
            playerAnimator.SetBool("isDead", true);
            gameManager.setAlive(false);
            StopCoroutine(StartFlightTimer());
        }
        else
        {
            StartCoroutine(Revive());
            extraLife = false;
        }
    }

    private IEnumerator Revive()
    {
        float gravity = rb.gravityScale;
        transform.position = new Vector3(transform.position.x, gameManager.StartPoint.y + 6, transform.position.z);
        rb.gravityScale = 0;
        jumpCounter = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        punchCounter = 0;
        reviveSound.Play();
        yield return new WaitForSeconds(1.5f);
        punchCounter++;
        refillJumps();
        rb.gravityScale = gravity;

    }

    //Resets jump counter
    private void refillJumps()
    {
        jumpCounter = totalJumpsAllowed;
    }

    public void enableJumpButton()
    {
        jumpButtonEngaged = true;

        if(jumpCounter > 0)
        {
            Jump();
            jumpCounter--;  
        }
        
        
    }

    public void disableJumpButton()
    {
        jumpButtonEngaged = false;
        //Debug.Log("JUMP DISABLED");
    }

    public void Jump()
    {
        //mouse button makes ET jump                                      //cant double jump && already jumped
        if ((touchingGround || jumpCounter > 0) && jumpButtonEngaged && !punching )   
        {
            //rb.AddForce(transform.up * currentJumpForce); //old way for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();

        }

    }

    //Applies gravity while jumping
    private void applyGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //character leaves ground
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = false;
            playerAnimator.SetBool("Grounded", touchingGround);
            StartCoroutine("StartFlightTimer");
        }
    }

    


    public void setJumpingCondtion(bool jump)
    {
        shouldJump = jump;
    }


    /**resets input listener back to default state
     */
    public void Reset()
    {
        playerAnimator.SetBool("isDead", false);
        currentSpeed = moveSpeed;
        currentJumpForce = jumpForce;
        punching = false;
        punchingFire.SetActive(false);
        if(skinID == 4)
        {
            extraLife = true;
        }


        
    }

    public float getCurrentSpeed()
    {
        return currentSpeed;
    }


    private IEnumerator StartFlightTimer()
    {
        Debug.Log("starting flight timer");
        yield return new WaitForSeconds(15);
        Debug.Log("flight timer ended");
        Achievements.UnlockIBelieveICanFly();
    }

}

