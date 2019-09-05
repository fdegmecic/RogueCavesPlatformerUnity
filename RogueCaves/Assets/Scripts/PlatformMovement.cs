using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTrasnform;
    [SerializeField]
    private Transform transfomB;


	void Start () {

        posA = childTrasnform.localPosition;
        posB = transfomB.localPosition;
        nexPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void move()
    {
        childTrasnform.localPosition = Vector3.MoveTowards(childTrasnform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTrasnform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}

