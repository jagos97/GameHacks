using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDebuff : MonoBehaviour
{

    public GameObject destructionPoint;
    public Pooler pool;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        destructionPoint = GameObject.Find("Destruction Point");
        pool = GameObject.Find("debuffPool").GetComponent<Pooler>();
        sound = GameObject.Find("DebuffPickup").GetComponent<AudioSource>();

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
            pool.deactivateObject(gameObject);
            sound.Play();
        }
    }
}
