using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public Animator doorAnimator;


	void Awake ()
	{
		doorAnimator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		doorAnimator.Play("DoorClose");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider target)
	{
		if (target.tag == TagsHelper.PLAYER_TAG) {
			doorAnimator.Play("DoorOpen");
		}
	}

	void OnTriggerExit (Collider target)
	{
		if (target.tag == TagsHelper.PLAYER_TAG) {
			doorAnimator.Play("DoorClose");
		}
	}
}
