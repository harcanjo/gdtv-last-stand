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

	void Start ()
	{
		GameController.instance.DisplayHealth(health);
	}

	public void ApplyDamage(int damageAmount){
		health -= damageAmount;

		if (health < 0)
		{
			health = 0;
		}

		// displayHealth value
		// Debug.Log("Player Health: " + health);
		GameController.instance.DisplayHealth(health);

		if (health == 0)
		{
			playerController.enabled = false;
			playerAnimator.Play(TagsHelper.DEAD_ANIMATION);

			// call game over
			GameController.instance.isPlayerAlive = false;

			// TODO: call game over panel

		}
	}

	void OnTriggerEnter (Collider target)
	{
		if (target.tag == TagsHelper.COIN_TAG){

			target.gameObject.SetActive(false);

			GameController.instance.CoinCollected();
			SoundManager.instance.PlayCoinSound();
		}
	}
}
