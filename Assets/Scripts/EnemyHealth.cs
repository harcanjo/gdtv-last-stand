using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health = 100;

	private EnemyController enemyController;
	private Animator enemyAnimator;

	void Awake ()
	{
		enemyController = GetComponent<EnemyController>();
		enemyAnimator =  GetComponentInChildren<Animator>();
	}

	public void ApplyDamage(int damageAmount){
		health -= damageAmount;

		if (health < 0)
		{
			health = 0;
		}

		// TODO: displayHealth value

		if (health == 0)
		{
			enemyController.enabled = false;
			enemyAnimator.Play(TagsHelper.DEAD_ANIMATION);

			Invoke("DeactivateEnemy", 3f);
		}
	}

	void DeactivateEnemy() {
		gameObject.SetActive(false);
	}
}
