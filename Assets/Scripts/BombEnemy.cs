using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    public GameObject BombPrefab;
    public Transform firePoint;

    public float throwTime;
    private float throwCount;

    
    void Start()
    {
        Destroy(gameObject,20f);//usar só no caso de SpawnPlatformV2
    }

    // Update is called once per frame
    void Update()
    {
        throwCount += Time.deltaTime;
        
        if(throwCount >= throwTime)
        {
            Instantiate(BombPrefab,firePoint.position,firePoint.rotation); 
            throwCount = 0f;

        }
    }
}
