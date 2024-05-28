using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public Animator levelPanelAnimator;
	public Animator creditsPanelAnimator;

	public void PlayGame() {
		levelPanelAnimator.Play("SlideIn");
	}

	public void CreditsGame() {
		creditsPanelAnimator.Play("SlideIn");
	}

	public void BackMenu() {
		levelPanelAnimator.Play("SlideOut");
	}

	public void CreditsBackMenu() {
		creditsPanelAnimator.Play("SlideOut");
	}

	public void QuitRequest(){
		// Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
