using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public int spawnChance;
    public Pooler pool;


    /**
     *This function will spawn enemy at a given platform either at the front mid or end of the platform
     * It handles the probabilty itself no need to do it
     */
    public void SpawnEnemy(GameObject platform)
    {
        if(UnityEngine.Random.Range(1,101) <= spawnChance)
        {
            int location = UnityEngine.Random.Range(0, 3);
            if (location == 0)
                SpawnAtBeginning(platform);
            else if (location == 1)
                SpawnAtMiddle(platform);
            else
                SpawnAtEnd(platform);
        }
    }

    /**
     *Spawns at the end of platform
     */
    private void SpawnAtEnd(GameObject platform)
    {
        float pointToSpawn = platform.transform.position.x + platform.GetComponent<BoxCollider2D>().bounds.size.x / 2 - 2.0f;
        SpawnAtPoint(platform, pointToSpawn);
    }

    /**
    *Spawns at the middle of platform
    */
    private void SpawnAtMiddle(GameObject platform)
    {
        float pointToSpawn = platform.transform.position.x;
        SpawnAtPoint(platform, pointToSpawn);
    }

    /**
    *Spawns at the beginning of platform
    */
    private void SpawnAtBeginning(GameObject platform)
    {
        float pointToSpawn = platform.transform.position.x - platform.GetComponent<BoxCollider2D>().bounds.size.x / 2 + 2.0f ;
        SpawnAtPoint(platform, pointToSpawn);
    }

    /**
     *Spawns given enemy on given platform at given point
     */
    private void SpawnAtPoint(GameObject platform, float pointToSpawn)
    {
        GameObject enemy = pool.getUnactiveObject();
        enemy.transform.position = new Vector3(pointToSpawn, platform.transform.position.y + platform.GetComponent<BoxCollider2D>().bounds.size.y / 2 + enemy.GetComponent<BoxCollider2D>().bounds.size.y/2, platform.transform.position.z);
        enemy.SetActive(true);
    }
}
