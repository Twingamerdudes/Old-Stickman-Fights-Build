using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public Rigidbody2D rb;
	public int Damage;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{ 
		if (hitInfo.tag != "Hands" && hitInfo.tag != "Player")
		{
			Enemy enemy = hitInfo.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(Damage);
				Destroy();
			}
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
}
