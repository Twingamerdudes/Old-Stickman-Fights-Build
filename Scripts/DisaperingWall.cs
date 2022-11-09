using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisaperingWall : MonoBehaviour
{
    public GameObject enemy;
    public Animator anim;
    public bool SpawnEnemy;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<Balance>().force == 0)
        {
            anim.SetBool("Destroy", true);
            if(SpawnEnemy == true)
            {
                Enemy.SetActive(true);
            }
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
