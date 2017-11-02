using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimScript : MonoBehaviour {

    private Animator anim;

	void Start ()
    {
        anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.CrossFade("walk", 0.1f);
        }
            if (Input.GetKey(KeyCode.Z))
        {
            anim.SetFloat("isWalking", 1);
            anim.SetFloat("isIdle", 0);
        }
        else
        {
            anim.SetFloat("isWalking", 0);
            anim.SetFloat("isIdle", 1);
        }
	}
}
