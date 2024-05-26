using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;

	private PlayerController playerController;
	private Animator playerAnimator;

	void Awake ()
	{
		playerController = GetComponent<PlayerController>();
		playerAnimator =  GetComponentInChildren<Animator>();
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
			playerController.enabled = false;
			playerAnimator.Play(TagsHelper.DEAD_ANIMATION);

			// TODO: call game over
		}
	}


}
