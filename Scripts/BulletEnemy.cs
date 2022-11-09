using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
	public float speed = 20f;
	public Rigidbody2D rb;
	public int Damage;
	public GameObject player;
	public bool left = false;
	// Use this for initialization
	void Start()
	{
		if(left == false)
        {
			rb.velocity = transform.right * speed;
        }
        else
        {
			rb.velocity = transform.right * -speed;
		}	
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{ 
		
		if (hitInfo.tag != "Enemy")
		{
			if (hitInfo.tag == "Ground")
			{
				Destroy();
			}
			if (hitInfo.tag == "OuterMap")
			{
				Destroy();
			}
			if (hitInfo.tag == "Void")
			{
				Destroy();
			}
			if (hitInfo.tag == "Carryable")
			{
				Destroy();
			}
			if (hitInfo.tag == "TouchWeapon")
			{
				Destroy();
			}
		}




	}
	void Destroy()
    {
		
		Destroy(gameObject);
	}
	public void ChangeDir(bool Isleft)
    {
		left = Isleft;
    }
}
