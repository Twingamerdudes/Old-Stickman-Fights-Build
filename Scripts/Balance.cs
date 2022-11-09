using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float restingAngle = 0f;
    public float force = 750f;
    public GameObject particles;
    public GameObject SpawnPoint;
    public GameObject Hips;
    public GameObject Cam;

    private Rigidbody2D rb;
    public bool Dead;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, restingAngle, force * Time.deltaTime));
        if(Hips.GetComponent<PlayerController>().HP == 0 || Hips.GetComponent<PlayerController>().HP < 0)
        {
            force = 0;
            Hips.GetComponent<PlayerController>().Panel.SetActive(true);
            Hips.GetComponent<PlayerController>().StartDelay();
            delay();

        }
        

    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.tag == "TouchWeapon")
        {
            if(gameObject.tag == "Enemy")
            {
                force = 0;
                particles.SetActive(false);
                particles.SetActive(true);
                GetComponent<Pathfinding.AIPath>().maxSpeed = 0;
                Dead = true;
                delay();

            }
            else
            {
                force = 0;
                particles.SetActive(false);
                particles.SetActive(true);
                Hips.GetComponent<PlayerController>().DieWithDelay();
                delay();

            }
        }
    }
    public IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        particles.SetActive(false);
    }
    public void Die()
    {
        force = 0;
        particles.SetActive(false);
        particles.SetActive(true);
        delay();
    }

}
