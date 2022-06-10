using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCamPos = new Vector3(player.position.x + offset,0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position,newCamPos, speed * Time.deltaTime);
    }
}
