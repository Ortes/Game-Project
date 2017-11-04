using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimScript : MonoBehaviour {

    public float speed = 2f;

    private Animator anim;
    private Rigidbody rb;

	void Start ()
    {
        anim = GetComponent <Animator> ();
        rb = GetComponent <Rigidbody> ();
        anim.speed = speed;
    }

    // Update is called once per frame
    void Update ()
    {
        float vaxe = Input.GetAxis("Vertical") * speed;
        if (vaxe != 0f)
        {
            anim.SetBool("IsWalking", true);
            Vector3 newPos = rb.position + new Vector3(0, 0, vaxe) * Time.deltaTime;
            rb.MovePosition(newPos);
        }
        else
            anim.SetBool("IsWalking", false);

	}
}
