using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform finalPoint;

    public SpawnEnemiesPlatform spawnObj;

    private void Start()
    {
        Destroy(gameObject,20f);//s� usar caso n�o estiver usando o recycle
    }
}
