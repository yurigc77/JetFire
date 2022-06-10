using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text vida;
    public int health;

    private Rigidbody2D rig;
    public Animator anim;
    
    public float speed;
    public float jumpForce;

    private bool isJumping;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        rig= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;

        vida.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.X))
        {
            OnShoot();
        }
        if (Input.GetKeyDown(KeyCode.Z))//pular
        {
            OnJump();
        }
    }

    public void OnShoot()
    {
        if(coolDown>=0.2)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            coolDown=0;
        }
        
    }

    public void OnJump()
    {
        if (!isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            isJumping = true;
        }
    }

    private void FixedUpdate() 
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    public void OnHit(int dmg)
    {
        health -= dmg;

        if(health<=0)
        {
            GameController.instance.ShowGameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==6)//verifica se esta na plataforma
        {
            isJumping = false;
            anim.SetBool("jumping",false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)//verifica se encostou no inimigo
    {
        if (collision.CompareTag("Enemy"))
        {
            OnHit(1);
        }
    }
}
