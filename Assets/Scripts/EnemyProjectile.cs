using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;

    public int damage;

    public GameObject explosionPrefab;

    private float lifeTime;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime>=1f)
        {
            Explode();
        }
    }


    void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }

    public void OnHit()
    {
        GameObject e = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit();
        
        if (collision.CompareTag("Player"))
        {
            player.OnHit(damage);
        }

    }

    public void Explode()
    {
        GameObject e = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 1f);
        Destroy(gameObject);
    }
}
