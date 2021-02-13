using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{

    public GameObject destructionPoint;
    public Pooler pool;

    // Start is called before the first frame update
    void Start()
    {
        destructionPoint = GameObject.Find("Destruction Point");
        pool = GameObject.Find("PlatformPooler").GetComponent<Pooler>();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < destructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            pool.deactivateObject(gameObject);
           
        }
    }
}
