using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") || Input.GetKey("up"))
        {
            Jump();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector2(0, 500); 
    }
}
