using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;

    public int damage;

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * speed;
    }

    public void OnHit()
    {
        GameObject e=Instantiate(explosionPrefab,transform.position,transform.rotation);
        Destroy(e, 1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==6)
        {
            OnHit();
        }
    }
}
