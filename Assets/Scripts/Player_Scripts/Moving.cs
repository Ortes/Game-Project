using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    
    public float speed;
    private Rigidbody rb;

    void Start()// Use this for initialization
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()//Update per frame for physics
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement*speed);
    }
}
