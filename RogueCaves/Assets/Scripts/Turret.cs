using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public int curHealth;
    public int maxHealth;

    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Animator anim;

    AudioManager audiomanager;
    public Transform target;
    public Transform shootPointLeft, shootPointRight;



    void Start()
    {
        curHealth = maxHealth;
        anim = GetComponent<Animator>();
        audiomanager = AudioManager.instance;
    }

    void Update()
    {
        
        RangeCheck();

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
        if (target.transform.position.x < transform.position.y)
        {
            lookingRight = false;
        }
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            awake = true;
        }

        if (distance > wakeRange)
        {
            awake = false;
        }

    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;

            direction.Normalize();

            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation);
                audiomanager.playSound("TurretSound");
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }

            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation);
                audiomanager.playSound("TurretSound");
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletClone.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);

                bulletTimer = 0;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            anim.Play("TurretDeath");
            audiomanager.playSound("TurretDeath");

            Invoke("DestroyObject", 0.2f);
        }
    }
     
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
