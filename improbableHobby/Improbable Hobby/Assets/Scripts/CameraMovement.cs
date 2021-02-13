using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;


    private float distanceFromPlayer;
    private float defaultDistance;

    private bool movingLeft = true;
    private int debuff = 0;
    private static bool flipped = false;
    public float timeBetweenInSeconds;

    public static bool Flipped { get => flipped; set => flipped = value; }

    // Start is called before the first frame update
    void Start()
    {
        distanceFromPlayer = transform.position.x - player.transform.position.x;
        defaultDistance = distanceFromPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + distanceFromPlayer, transform.position.y, transform.position.z);

        if (debuff == 1)
        {
            debuff1();
        }
        else if(debuff >= 2)
        {
            debuff2();
        }
    }



    /*
     *For the first 2 levels of this debuff it moves the camara but in reality the camara is either 
     *  Moving left: slows down the camara so that M'eme moves more to the center or
     *  !Moving left: speeds up the camara and move M'eme more to the right 
     *  
     *  We can play around with the limits of ie. the distance from the player and also the speed 
     *  in which it is increasing or decreasing
     * 
     */
    private void debuff1()
    {
        if (movingLeft)
        {
            if (defaultDistance - 4 > distanceFromPlayer)
            {
                movingLeft = false;
            }
            else
            {
                distanceFromPlayer -= 0.04f;
            }

        }
        else
        {
            if (defaultDistance < distanceFromPlayer)
            {
                movingLeft = true;
            }
            else
            {
                distanceFromPlayer += 0.02f;
            }
        }
    }

    private void debuff2()
    {
        if (movingLeft)
        {
            if (defaultDistance - 4 > distanceFromPlayer)
            {
                movingLeft = false;
            }
            else
            {
                distanceFromPlayer -= 0.08f;
            }

        }
        else
        {
            if (defaultDistance < distanceFromPlayer)
            {
                movingLeft = true;
            }
            else
            {
                distanceFromPlayer += 0.04f;
            }
        }
    }

    public void flipCamera()
    {
        transform.Rotate(0, 0, 180);
        flipped = !flipped;
    }

    public void addDebuffLevel()
    {
        debuff += 1;
    }
    public void ResetDebuffLevel()
    {
        debuff = 0;
        if (flipped)
        {
            flipCamera();
        }
    }

    public void startAssholeCamera()
    {
        StartCoroutine(FlipCameraToNormal());
    }

    private IEnumerator FlipCameraToNormal()
    {
        flipCamera();
        yield return new WaitForSeconds(timeBetweenInSeconds);
        if (debuff == 4)
        {
            StartCoroutine(FlipCameraUpsideDown());
        }
    }

    private IEnumerator FlipCameraUpsideDown()
    {
        if (debuff == 4)
        {
            flipCamera();
            yield return new WaitForSeconds(timeBetweenInSeconds);
            if (debuff == 4)
            {
                StartCoroutine(FlipCameraToNormal());
            }
        }
    }

}
