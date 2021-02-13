using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public Pooler coinPool;


    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.getUnactiveObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

    }

}
