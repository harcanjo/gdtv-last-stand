using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private Text healthText;
	private Text coinText;
	private Text timerText;

	private int coinScore;

	[HideInInspector]
	public bool isPlayerAlive;

	public float timerTime = 99f;

	void Awake ()
	{
		MakeInstance();

		healthText = GameObject.Find("HealthText").GetComponent<Text>();
		coinText = GameObject.Find("CoinText").GetComponent<Text>();
		timerText = GameObject.Find("TimerText").GetComponent<Text>();

		coinText.text = "Coins: " + coinScore;
	}

	void Start ()
	{
		isPlayerAlive = true;
	}


	void Update ()
	{
		CountdownTimer();
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
		coinText.text = "Coins: " + coinScore;
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
}
