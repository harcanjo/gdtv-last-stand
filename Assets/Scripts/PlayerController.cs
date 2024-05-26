﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody playerRigidbody;
	private Animator playerAnimator;
	public Transform groundCheck;
	public LayerMask groundLayer;

	private float moveHorizontal;
	private float moveVertical;
	private bool isPlayerMoving;
	private float playerSpeed = 0.3f;
	private float playerRotationSpeed = 3f;
	private float playerRotationY = 0f;

	private float playerJumpForce = 3f;
	private bool canPlayerJump;

	void Awake ()
	{
		playerRigidbody = GetComponent<Rigidbody>();
		playerAnimator = GetComponent<Animator>();
	}

	void Start () {
		playerRotationY = transform.localRotation.eulerAngles.y;
	}
	
	void Update () {
		PlayerKeyboardMovement();
		AnimatePlayer();
	}

	void FixedUpdate() {
		MoveAndRotate();
	}

	void PlayerKeyboardMovement()
	{
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			moveHorizontal = -1;
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) {
			moveHorizontal = 0;
		}

		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			moveHorizontal = 1;
		}

		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
			moveHorizontal = 0;
		}

		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			moveVertical = 1;
		}

		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)) {
			moveVertical = 0;
		}

		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			moveVertical = -1;
		}

		if (Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow)) {
			moveVertical = 0;
		}
	}

	void MoveAndRotate ()
	{
		if (moveVertical != 0) {
			playerRigidbody.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
		}

		playerRotationY += moveHorizontal * playerRotationSpeed;
		playerRigidbody.rotation = Quaternion.Euler(0f, playerRotationY, 0f);
	}

	void AnimatePlayer ()
	{

		if (moveVertical != 0) {

			if (!isPlayerMoving) {
				if (moveVertical > 0 && !playerAnimator.GetCurrentAnimatorStateInfo (0).IsName (TagsHelper.RUN_ANIMATION)) {
					isPlayerMoving = true;
					playerAnimator.SetTrigger (TagsHelper.RUN_TRIGGER);	
				}
			}
			// TODO: set animation to run back - motion/speed * -1
		} else {

			if (isPlayerMoving) {
				if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(TagsHelper.RUN_ANIMATION)){
					isPlayerMoving = false;
					playerAnimator.SetTrigger(TagsHelper.STOP_TRIGGER);	
				}
			}
		}
	}
}
