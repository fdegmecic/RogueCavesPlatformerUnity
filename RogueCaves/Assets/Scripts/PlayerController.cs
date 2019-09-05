using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public float jumpForce = 800f;
    public LayerMask whatIsGround;
    bool doubleJump = false;

    public float curHeatlth;
    public float maxHealth = 100;
    public bool isDead = false;
    public bool isFalling = false;

    public Transform FirePosition;
    public GameObject Bullet;

 

    Rigidbody2D rb;
    Animator anim;
    AudioManager audiomanager;
    Menu menu;

    void Start()
    {   
        audiomanager = AudioManager.instance;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        menu = FindObjectOfType<Menu>();
        anim.SetBool("IsDead", false);
        curHeatlth = maxHealth;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;

        anim.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.y);

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Update()
    {
        GetInputMovement();

        if (curHeatlth > maxHealth)
        {
            curHeatlth = maxHealth;
        }

        if (curHeatlth <= 0)
        {
            Die();
            Invoke("DestroyPlayer", 0.5f);
            isDead = true;
            
        }
    }

    void GetInputMovement()
    {
        if (isFalling)
        {
            gameObject.layer = 11;
        }
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetBool("Ground", false);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
                doubleJump = true;
        }

        if (Input.GetButtonDown("Fire1") && menu.isPaused==false){
            
            GameObject mBullet = Instantiate(Bullet, FirePosition.position, FirePosition.rotation);

            audiomanager.playSound("ShootSound");

            mBullet.transform.parent = GameObject.Find("GameMaster").transform;

            mBullet.GetComponent<Renderer>().sortingLayerName = "Player";

            anim.SetBool("Shooting", true);
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Shooting", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    void Die()
    {
        rb.velocity = Vector2.zero;
        anim.SetBool("IsDead", true);
        audiomanager.playSound("PlayerDeath");
        GetComponent<PlayerController>().enabled = false;

       
    }
    public void Damage(int dmg)
    {
        curHeatlth -= dmg;
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    void Falling()
    {
        if (rb.velocity.y < 0) {
            isFalling = true;
                };  
    }

    
}
