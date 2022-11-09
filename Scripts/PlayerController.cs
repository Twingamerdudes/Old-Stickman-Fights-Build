using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Inspector
    [Header("Movement")]
    public float movementForce;
    public float jumpForce;
    [Space(5)]
    [Range(0f, 100f)] public float raycastDistance = 1.5f;
    public LayerMask whatIsGround;

    [Header("Camera Follow")]
    public Camera cam;
    [Range(0f, 1f)] public float interpolation = 0.1f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    [Header("Animation")]
    public Animator anim;
    public Transform head;

    private Rigidbody2D rb;

    [Header("Other")]
    public int HP;
    public GameObject Body;
    public GameObject SpawnPoint;
    public GameObject Panel;




    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        //Loop
        GameTick();
        Movement();
        Jump();
        CameraFollow();
    }
    public void GameTick()
    {
        if(HP == 0 || HP < 0)
        {
            this.GetComponent<Balance>().force = 0;
            Body.GetComponent<Balance>().force = 0;
            movementForce = 0;
            jumpForce = 0;
            StartCoroutine(Delay2());
        }
    }
    private void Movement() 
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);

        // animation

        if (xDir != 0) 
        {
            head.localScale = new Vector3(xDir, 1f, 1f);
        }
        if (xDir > 0) 
        {
            anim.SetBool("Walk", true);
            anim.SetBool("WalkBack", false);
        }
        if (xDir < 0) 
        {
            anim.SetBool("Walk", false);
            anim.SetBool("WalkBack", true);
        }
        if (xDir == 0) 
        {
            anim.SetBool("Walk", false);
            anim.SetBool("WalkBack", false);
        }
    }

    private void Jump() 
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
    }

   private bool IsGrounded() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }

    //Cam
    private void CameraFollow() 
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, interpolation);
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        //Collsions
        if (collisioninfo.tag == "TouchWeapon")
        {
            movementForce = 0;
            jumpForce = 0;
        }
        if (collisioninfo.tag == "Enemy")
        {
            if(collisioninfo.GetComponent<Balance>().Dead == false && collisioninfo.GetComponent<Balance>().force != 0)
            {
                GetComponent<Balance>().particles.SetActive(false);
                GetComponent<Balance>().particles.SetActive(true);
                HP--;
            }
           
        }
        if (collisioninfo.tag == "Void")
        {
            Die();
        }
        if (collisioninfo.tag == "End")
        {
            TheEnd();
        }

    }
    //Delays
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }
    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(1);
        Panel.SetActive(true);
        StartDelay();
    }
    IEnumerator Delay3()
    {
        yield return new WaitForSeconds(1);
        Die();
    }
    IEnumerator Delay4()
    {
        yield return new WaitForSeconds(1);
        Panel.SetActive(true);
        StartDelay2();
    }
    IEnumerator Delay5()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);

    }
    public void TakeDamage(int damage)
    {
        GetComponent<Balance>().particles.SetActive(false);
        GetComponent<Balance>().particles.SetActive(true);
        HP -= damage;
    }
    public void Die()
    {
        HP = 0;
    }
    public void TheEnd()
    {
        StartCoroutine(Delay4());
    }
    public void DieWithDelay()
    {
        movementForce = 0;
        jumpForce = 0;
        Body.GetComponent<Balance>().Die();
        StartCoroutine(Delay3());
    }
    public void StartDelay()
    {
        StartCoroutine(Delay());
    }
    public void StartDelay2()
    {
        StartCoroutine(Delay5());
    }
}