using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{

    public GameObject pooledObject;


    public GameObject[] defaults;
    public int numOfAdditionalObjects;

    List<GameObject> activePool;
    List<GameObject> inactivePool;



    // Start is called before the first frame update
    void Awake()
    {

        activePool = new List<GameObject>();
        inactivePool = new List<GameObject>();


        for (int i = 0; i < defaults.Length; i++)
        {
            for(int j = 0; j < numOfAdditionalObjects; j++)
            {
                GameObject obj = (GameObject)Instantiate(defaults[i]);
                obj.SetActive(false);
                inactivePool.Add(obj);
            }
        }

 
    }


    public GameObject getUnactiveObject()
    {
        if (inactivePool.Count > 0)
        {
            int i = Random.Range(0, inactivePool.Count);
            GameObject obj = inactivePool[i];
            inactivePool.RemoveAt(i);
            obj.SetActive(true);
            activePool.Add(obj);
            return obj;
        }
        else
        {
            GameObject obj = (GameObject)Instantiate(defaults[0]);
            obj.SetActive(true);
            activePool.Add(obj);
            return obj;
        }

    }

    public void deactivateObject(GameObject obj)
    {
        activePool.Remove(obj);
        inactivePool.Add(obj);
        obj.SetActive(false);
        
    }

    public void Reset()
    {
        int size = activePool.Count;
        for (int i = 0; i < size ; i++)
        {
            GameObject obj = activePool[0];
            activePool.RemoveAt(0);
            obj.SetActive(false);
            inactivePool.Add(obj);
        }
    }


    
    


}
