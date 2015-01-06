using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerPhysics))]

public class PlayerControl : MonoBehaviour {

	public float walkingAcc = 10;
	public float runningAcc = 19;
	public float sneakingAcc = 7;
	public float walkingSpeed = 8;
	public float runningSpeed = 16;
	public float sneakingSpeed = 5;

	private float acceleration;
	private float speed;
	private PlayerPhysics physics;
	private float targetSpeed;
	private float currentSpeed;
	private Vector3 amountToMove;

	// Use this for initialization
	void Start () {
		speed = walkingSpeed;
		physics = GetComponent<PlayerPhysics> ();
		acceleration = walkingAcc;
	}
	
	// Update is called once per frame
	void Update () {

		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		amountToMove.x = currentSpeed;
		amountToMove.z = 0;
		amountToMove.y = 0;

		physics.Move (amountToMove);
	
	}

	private float IncrementTowards(float n, float target, float a){
		if(n == target){
			return n;
		}
		else{
			float dir = Mathf.Sign(target-n);
			n+=a*Time.deltaTime*dir;
			return(dir == Mathf.Sign(target-n))? n: target;
		}
	}
}
