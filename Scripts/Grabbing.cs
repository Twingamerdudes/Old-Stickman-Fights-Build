using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    [HideInInspector]
    public Transform firePoint;

    public Rigidbody2D hand;
    [Range(0, 1)] public int isLeftOrRight;

    public GameObject currentlyHolding;
    private bool canGrab;
    private FixedJoint2D joint;
    public GameObject bulletPrefab;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(isLeftOrRight)) 
        {
            canGrab = true;
        }
        if (Input.GetMouseButtonUp(isLeftOrRight)) 
        {
            canGrab = false;
        }

        if (!canGrab && currentlyHolding != null) 
        {
            FixedJoint2D[] joints = currentlyHolding.GetComponents<FixedJoint2D>(); 
            for (int i = 0; i < joints.Length; i ++) 
            {
                if (joints[i].connectedBody == hand) 
                {
                    Destroy(joints[i]);
                }
            }

            joint = null;
            currentlyHolding = null;
        }
        if (currentlyHolding.tag == "Pistol")
        {
            firePoint = currentlyHolding.GetComponentInChildren<Vertify>().Name;
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (canGrab && col.gameObject.GetComponent<Rigidbody2D>() != null && col.gameObject.tag == "Carryable" || col.gameObject.tag == "Pistol") 
        {
            currentlyHolding = col.gameObject;
            joint = currentlyHolding.AddComponent<FixedJoint2D>();
            joint.connectedBody = hand;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}