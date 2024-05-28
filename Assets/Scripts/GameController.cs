using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private Text healthText;
	private Text coinText;
	private Text timerText;

	private int coinScore;

	[HideInInspector]
	public bool isPlayerAlive;

	public float timerTime = 60f;

	public GameObject endPanel;
	public GameObject winPanel;


	void Awake ()
	{
		// Time.timeScale = 1f;
		MakeInstance();

		healthText = GameObject.Find("HealthText").GetComponent<Text>();
		coinText = GameObject.Find("CoinText").GetComponent<Text>();
		timerText = GameObject.Find("TimerText").GetComponent<Text>();

		coinText.text = "Coins: " + coinScore + " / 10";
	}

	void Start ()
	{
		isPlayerAlive = true;

		endPanel.SetActive(false);
		winPanel.SetActive(false);
	}


	void Update ()
	{
		CountdownTimer ();

		if (timerTime <= 0) {
			GameOver();
		}

		if (coinScore >= 10) {
			GameWin();
		}

		// TODO: to restart level during development
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}


	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy(gameObject);
		}
	}

	public void CoinCollected ()
	{
		coinScore++;
		coinText.text = "Coins: " + coinScore + " / 10";
	}


	public void DisplayHealth (int health)
	{		
		healthText.text = "Health: " + health;
	}


	public void CountdownTimer ()
	{
		timerTime -= Time.deltaTime;
		timerText.text = "Time: " + timerTime.ToString("F0");
	}

	public void GameOver() {
		// TODO: Block user input
		// Time.timeScale = 0f;
		endPanel.SetActive(true);
	}

	public void GameWin() {
		// TODO: Block user input
		// Time.timeScale = 0f;
		winPanel.SetActive(true);
	}

	public void LoadLevel(string name){
		// Debug.Log ("New Level load: " + name);
		// Application.LoadLevel (name);
		SceneManager.LoadScene(name);
	}

	// TODO: Create a restart level
	public void RestartLevel ()
	{
		// Reset timescale to normal speed
	    Time.timeScale = 1f;
	    
	    // Reload the scene
	    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
