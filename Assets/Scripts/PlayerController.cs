using System.Collections;
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
	private float playerSpeed = 0.35f;
	private float playerRotationSpeed = 3.2f;
	private float playerRotationY = 0f;

	private float playerJumpForce = 3.2f;
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
	}

	void FixedUpdate () {
		MoveAndRotate();
	}

	void PlayerKeyboardMovement ()
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
}
