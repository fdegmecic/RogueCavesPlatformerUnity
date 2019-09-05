using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour
{


    public float health = 100f;
    public Transform target;
    public float engageDistance = 10f;
    public float attackDistance = 3f;
    public float moveSpeed = 5f;
    private bool facingLeft = true;
    private Animator anim;
    public PlayerController player;
    public float attackDamage = 5;
    AudioManager audiomanager;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        audiomanager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsIdle", true);
        anim.SetBool("IsWalking", false);

        if (Vector3.Distance(target.position, this.transform.position) < engageDistance)
        {
            anim.SetBool("IsIdle", false);
            //direkcija mete
            Vector3 direction = target.position - this.transform.position;

            if (Mathf.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if (Mathf.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }

            if (direction.magnitude >= attackDistance)
            {
                anim.SetBool("IsWalking", true);
                

                Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);

                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
                }

            }
            if (direction.magnitude < attackDistance)
            {
                Debug.DrawLine(target.transform.position, this.transform.position, Color.red);
                player.GetComponent<PlayerController>().curHeatlth -= attackDamage;
                audiomanager.playSound("CrabAttack");

            }

        }
        else if (Vector3.Distance(target.position, this.transform.position) > engageDistance)
        {
            Debug.DrawLine(target.position, this.transform.position, Color.green);
         
        }



    }
    
    private void Flip()
    {
        facingLeft = !facingLeft;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 100;

            anim.SetBool("IsDead", true);
            audiomanager.playSound("CrabDeath");

            Invoke("DestroyCrab", 0.3f);
            attackDamage = 0;
        }
    }

    void DestroyCrab()
    {
        Destroy(gameObject);
    }

}

