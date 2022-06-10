using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rig;
    private Player player;

    public GameObject explosionPrefab;

    public int damage;

    public float xAxis;
    public float yAxis;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player").GetComponent<Player>();

        rig=GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis,yAxis),ForceMode2D.Impulse);

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
