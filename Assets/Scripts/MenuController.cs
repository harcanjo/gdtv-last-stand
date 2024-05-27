using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public Animator levelPanelAnimator;


	public void PlayGame() {
		levelPanelAnimator.Play("SlideIn");
	}

	public void BackMenu() {
		levelPanelAnimator.Play("SlideOut");
	}
}
