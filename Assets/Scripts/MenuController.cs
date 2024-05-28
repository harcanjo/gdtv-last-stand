using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public void LoadLevel(string name){
		// Debug.Log ("New Level load: " + name);
		// Application.LoadLevel (name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		// Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
