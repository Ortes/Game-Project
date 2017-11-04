using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimScript : MonoBehaviour {

    public float speed = 2.5f;

    private Animator anim;

	void Start ()
    {
        anim = GetComponent <Animator> ();
        anim.speed = speed;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxis("Vertical") != 0f)
        {
            anim.SetBool("IsWalking", true);
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime));
        }
        else
            anim.SetBool("IsWalking", false);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * speed);
	}
}
