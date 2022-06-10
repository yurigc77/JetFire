using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformsV2 : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();//lista dos prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>();//lista das plataformas geradas (clones)

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    public float offset;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        CreatePlatforms();
        CreatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x; //diferença da posição do player em relação a plataforma atual

        if (distance >= 1)
        {
            CreatePlatforms();

            currentPlatforms[platformIndex] = null;
            platformIndex++;

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    public void CreatePlatforms()
    {
        Transform p = Instantiate(platforms[Random.Range(0, platforms.Count)], new Vector2(offset * 30, -4.5f), transform.rotation).transform;
        currentPlatforms.Add(p);
        offset++;

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }
}
