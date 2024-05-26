using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventHelper : MonoBehaviour {

	public EnemyController enemyController;

	public void CallActivateDamagePoint() {
		enemyController.ActivateDamagePoint();
	}

	public void CallDeactivateDamagePoint() {
		enemyController.DeactivateDamagePoint();
	}
}
