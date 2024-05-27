using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventHelper : MonoBehaviour {

	public PlayerController playerController;

	public void CallActivateDamagePoint() {
		print("activated");
		playerController.ActivateDamagePoint();
	}

	public void CallDeactivateDamagePoint() {
		print("deactivated");
		playerController.DeactivateDamagePoint();
	}
}
