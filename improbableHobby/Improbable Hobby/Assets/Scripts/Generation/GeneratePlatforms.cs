using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{

    public GameObject LastDefaultplatform;
    public Vector3 startPoint;
    public float minDistance;
    public float maxDistance;
    public GameObject poolerObject;
    public DebuffGenerator debuffGenerator;


    public float platformWidth;

    private CoinGenerator TheCoinGenerator;
    private Vector3 gameStartPosition;
    private Pooler pooler;
    public int randomCoinThreshold = 25;  //75% chance to generate coin
    public int debuffThreshold;

    public GameObject lastPlatform;

    private EnemyGeneration enemyGeneration;

    // Start is called before the first frame update

    private void Awake()
    {
        pooler = poolerObject.GetComponent<Pooler>();
        platformWidth = getWidthofPlatform(LastDefaultplatform);
        startPoint = transform.position;

        debuffGenerator = FindObjectOfType<DebuffGenerator>();
        TheCoinGenerator = FindObjectOfType<CoinGenerator>();

        startPoint.x += platformWidth / 2 + Random.Range(minDistance, maxDistance);
        transform.position = startPoint;
        gameStartPosition = transform.position;
        enemyGeneration = GameObject.Find("EnemyGenerator").GetComponent<EnemyGeneration>();
    }

    void Start()
    {


        while(transform.position.x > startPoint.x)
        {
            GameObject obj = pooler.getUnactiveObject();
            platformWidth = getWidthofPlatform(obj);
            float height = Random.Range(0.0f, 4.0f);
            Vector3 newPosition = new Vector3(startPoint.x + platformWidth / 2, transform.position.y + height, obj.transform.position.z);
            obj.transform.position = newPosition;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
            enemyGeneration.SpawnEnemy(obj);
            startPoint.x += platformWidth + Random.Range(minDistance, maxDistance);
            lastPlatform = obj;

            if (Random.Range(0, 100) >= debuffThreshold)
            {
                float newX = (startPoint.x + newPosition.x + platformWidth / 2.0f) / 2.0f;
                float newY = newPosition.y + height + 2f;
                Vector3 debuffPosition = new Vector3(newX, newY, newPosition.z);
                debuffGenerator.spawnDebuff(debuffPosition);
            }


            if (Random.Range(0, 100) >= randomCoinThreshold)
            {
                newPosition.y += 1.0f;
                TheCoinGenerator.SpawnCoins(newPosition);
            }

        }





    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > startPoint.x)
        {
            GameObject obj = pooler.getUnactiveObject();
            platformWidth = getWidthofPlatform(obj);
            float height = Random.Range(0.0f, 4.0f);
            Vector3 newPosition = new Vector3(startPoint.x + platformWidth/2, transform.position.y + height, obj.transform.position.z);
            obj.transform.position = newPosition;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
            enemyGeneration.SpawnEnemy(obj);
            startPoint.x +=  platformWidth + Random.Range(minDistance, maxDistance);
            lastPlatform = obj;

            if (Random.Range(0, 100) >= debuffThreshold)
            {
                float newX = (startPoint.x + newPosition.x + platformWidth / 2.0f) / 2.0f ;
                float newY = newPosition.y + height + 2f;
                Vector3 debuffPosition = new Vector3(newX, newY, newPosition.z);
                debuffGenerator.spawnDebuff(debuffPosition);
            }


            if (Random.Range(0, 100) >= randomCoinThreshold) {
                newPosition.y += 1.0f;
                TheCoinGenerator.SpawnCoins(newPosition);
            }

            

            //Instantiate(platform, transform.position, transform.rotation);
        }
    }


    public void Reset()
    {
        startPoint = gameStartPosition;
    }



    private float getWidthofPlatform(GameObject platform)
    {
        return platform.GetComponent<BoxCollider2D>().bounds.size.x;
    }
}
