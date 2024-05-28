using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	public GameObject playButton;
	public GameObject quitButton;

	void DeactivateGameObjects ()
	{
		player.SetActive(false);
		enemy.SetActive(false);
		playButton.SetActive(false);
		quitButton.SetActive(false);
	}

	void ActivateGameObjects ()
	{
		player.SetActive(true);
		enemy.SetActive(true);
		playButton.SetActive(true);
		quitButton.SetActive(true);
	}
}
