using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour {

    public Turret turret;

    public bool isLeft = false;

    void Awake()
    {
        turret = gameObject.GetComponentInParent<Turret>();
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (isLeft)
            {
                turret.Attack(false);
            }
            else
            {
                turret.Attack(true);
            }
        }
        
    }

}
