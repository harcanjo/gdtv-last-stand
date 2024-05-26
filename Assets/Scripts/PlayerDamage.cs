using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	public int damageAmount = 15;
	public LayerMask enemyLayer;

	void Update ()
	{
		Collider[] hits = Physics.OverlapSphere (transform.position, 3f, enemyLayer);


		if (hits.Length > 0) {
			print(hits[0].gameObject.tag);
			if(hits[0].gameObject.tag == TagsHelper.ENEMY_TAG){

				// print("COLLIDED WITH ENEMY");
				hits[0].gameObject.GetComponent<EnemyHealth>().ApplyDamage(damageAmount);
			}
		}

	}
}
