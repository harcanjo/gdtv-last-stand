﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public int damageAmount = 2;
	public LayerMask playerLayer;

	void Update ()
	{
		Collider[] hits = Physics.OverlapSphere (transform.position, 3f, playerLayer);

		if (hits.Length > 0) {

			if(hits[0].gameObject.tag == TagsHelper.PLAYER_TAG){

				// print("COLLIDED WITH PLAYER");
				hits[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);
			}
		}

	}
}
