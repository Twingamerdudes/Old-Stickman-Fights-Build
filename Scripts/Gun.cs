using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject Enemy;
    public bool Dead;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
       if(Enemy.GetComponent<Balance>().Dead == true)
        {
            Dead = true;
        }
    }
    IEnumerator Shoot()
    {
        if(Dead == false)
        {
            yield return new WaitForSeconds(1);
            bulletPrefab.GetComponent<BulletEnemy>().ChangeDir(true);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Shoot());
        }  
    }
}
