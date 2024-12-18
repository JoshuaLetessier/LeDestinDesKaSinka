﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpousse : MonoBehaviour
{
	public float distance = 1f;
	public LayerMask boxMask;

	GameObject box;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

		if (hit.collider != null  && Input.GetKeyDown(KeyCode.E))
		{

			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			box.GetComponent<FixedJoint2D>().enabled = true;


		}

	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);



	}
}
