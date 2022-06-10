using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform finalPoint;

    public SpawnEnemiesPlatform spawnObj;

    private void Start()
    {
        Destroy(gameObject,20f);//só usar caso não estiver usando o recycle
    }
}
