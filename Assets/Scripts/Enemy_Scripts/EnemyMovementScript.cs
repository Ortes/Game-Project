using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
	GameObject player = null;
	UnityEngine.AI.NavMeshAgent nav;

	void Awake()
	{
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}

	void Update()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            nav.SetDestination (player.transform.position);
	} 
}