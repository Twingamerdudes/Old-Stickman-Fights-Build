using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPos : MonoBehaviour
{
    public GameObject Object;
    public float X;
    public float Y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            X = Object.transform.position.x;
            Y = Object.transform.position.y;
            gameObject.transform.position = new Vector2(X, Y);
        
    }
}
