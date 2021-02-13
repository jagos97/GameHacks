using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffGenerator : MonoBehaviour
{

    public Pooler debuffPool;

    public void spawnDebuff(Vector3 startPosition)
    {
        GameObject debuff = debuffPool.getUnactiveObject();
        debuff.transform.position = startPosition;
        debuff.SetActive(true);
    }


}
