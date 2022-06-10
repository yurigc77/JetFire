using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : MonoBehaviour
{
    //public GameObject enemyPrefab;
    public List<GameObject> enemy = new List<GameObject>();
    private GameObject currentEnemy;

    public List<Transform> points = new List<Transform>();

    
    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
    }


    public void Spawn(float offset)
    {
        if (currentEnemy == null)
        {
            CreateEnemy();
        }
        else
        {
            Destroy(currentEnemy);
            CreateEnemy();
            //currentEnemy.transform.position = new Vector3(currentEnemy.transform.position.x + offset, currentEnemy.transform.position.y, currentEnemy.transform.position.z);
        }
    }

    void CreateEnemy()
    {
        int pos = Random.Range(0,points.Count);
        GameObject e = Instantiate(enemy[Random.Range(0,enemy.Count)], points[pos].position, points[pos].rotation);
        currentEnemy = e;
    }
}
