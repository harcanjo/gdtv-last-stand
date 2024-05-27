using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	public GameObject playButton;



	void DeactivateGameObjects ()
	{
		player.SetActive(false);
		enemy.SetActive(false);
		playButton.SetActive(false);
	}

	void ActivateGameObjects ()
	{
		player.SetActive(true);
		enemy.SetActive(true);
		playButton.SetActive(true);
	}
}
