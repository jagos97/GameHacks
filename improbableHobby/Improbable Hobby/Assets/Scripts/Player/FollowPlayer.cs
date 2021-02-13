using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;


    private float distanceFromPlayer;
    private float defaultDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceFromPlayer = transform.position.x - player.transform.position.x;
        defaultDistance = distanceFromPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + distanceFromPlayer, transform.position.y, transform.position.z);


    }
}
