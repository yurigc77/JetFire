using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    private Rigidbody2D rig;
    public float speed;

    private Player player;

    public GameObject explosionPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig=GetComponent<Rigidbody2D>();
        Destroy(gameObject,5f);
    }

    private void FixedUpdate()
    {
            rig.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject e = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 1f);

        if (collision.CompareTag("Player"))
        {
            player.OnHit(damage);
        }
        Destroy(gameObject);
    }
}
