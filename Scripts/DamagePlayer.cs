using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public GameObject Hips;
    public GameObject EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int Damage)
    {
        Hips.GetComponent<PlayerController>().TakeDamage(Damage);
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if(collisioninfo.tag == "EnemyBullet")
        {
            TakeDamage(EnemyBullet.GetComponent<BulletEnemy>().Damage);
        }
    }
}
