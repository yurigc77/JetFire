using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();

    private float timerCount;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;

        if(timerCount >= spawnTime)
        {
            SpawnEnemy();
            timerCount = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0,enemiesList.Count)],transform.position + new Vector3(0,Random.Range(0f,3f),0),transform.rotation);
    }
}
