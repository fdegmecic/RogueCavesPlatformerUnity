using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger != true)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerController>().Damage(20);
                Destroy(gameObject);
            }
        }
    }
}
