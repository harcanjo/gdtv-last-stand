using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private GameObject player;
	private Rigidbody enemyRigidbody;
	private Animator enemyAnimator;

	private float enemeySpeed = 4f; // 10
	private float enemyWatchTreshold = 28f; // 70
	private float enemyAttackTreshold = 1.5f; // 6

	public GameObject damagePoint;

	void Awake () {
		player = GameObject.FindGameObjectWithTag(TagsHelper.PLAYER_TAG);
		enemyRigidbody = GetComponent<Rigidbody>();
		enemyAnimator = GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate ()
	{

		if (GameController.instance.isPlayerAlive) {
			EnemyAI ();
		} else {
			if (enemyAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.RUN_ANIMATION) ||
				enemyAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.ATTACK_ANIMATION)) {
				enemyAnimator.SetTrigger (TagsHelper.STOP_TRIGGER);
			}
		}
	}

	void EnemyAI ()
	{
		Vector3 direction = player.transform.position - transform.position;
		float distance = direction.magnitude;
		direction.Normalize ();

		Vector3 velocity = direction * enemeySpeed;

		if (distance > enemyAttackTreshold && distance < enemyWatchTreshold) {

			enemyRigidbody.velocity = new Vector3 (velocity.x, enemyRigidbody.velocity.y, velocity.z);

			if (enemyAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.ATTACK_ANIMATION)) {
				enemyAnimator.SetTrigger (TagsHelper.STOP_TRIGGER);
			}

			enemyAnimator.SetTrigger (TagsHelper.RUN_TRIGGER);

			transform.LookAt (new Vector3 (
				player.transform.position.x,
				transform.position.y,
				player.transform.position.z
			));
		} else if (distance < enemyAttackTreshold) {

			if (enemyAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.RUN_ANIMATION)) {
				enemyAnimator.SetTrigger (TagsHelper.STOP_TRIGGER);
			}

			enemyAnimator.SetTrigger (TagsHelper.ATTACK_TRIGGER);

			transform.LookAt (new Vector3 (
				player.transform.position.x,
				transform.position.y,
				player.transform.position.z
			));
		} else {
			enemyRigidbody.velocity = new Vector3(0f,0f,0f);

			if (enemyAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.RUN_ANIMATION) ||
				enemyAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.ATTACK_ANIMATION)) {
				enemyAnimator.SetTrigger (TagsHelper.STOP_TRIGGER);
			}
		}
	}

	public void ActivateDamagePoint() {
		damagePoint.SetActive(true);
	}

	public void DeactivateDamagePoint() {
		damagePoint.SetActive(false);
	}
}
