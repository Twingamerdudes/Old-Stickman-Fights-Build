using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP == 0 || HP < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GetComponent<Balance>().force = 0;
        GetComponent<Pathfinding.AIPath>().maxSpeed = 0;

    }
   
    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        GetComponent<Balance>().particles.SetActive(false);
        GetComponent<Balance>().particles.SetActive(true);
        
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.tag == "Carryable")
        {
            print(collisioninfo.GetComponent<Rigidbody2D>().velocity.x);
            print(collisioninfo.GetComponent<Rigidbody2D>().velocity.y);
            if (collisioninfo.GetComponent<Rigidbody2D>().velocity.x >= 1 || collisioninfo.GetComponent<Rigidbody2D>().velocity.y >= 1 || collisioninfo.GetComponent<Rigidbody2D>().velocity.y <= -1 || collisioninfo.GetComponent<Rigidbody2D>().velocity.x < -1)
            {
                GetComponent<Balance>().particles.SetActive(false);
                GetComponent<Balance>().particles.SetActive(true);
                Die();
            }
        }
        
    }


}
