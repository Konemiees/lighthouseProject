using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void Move(Vector3 amountToMove){

		Vector3 place = transform.position;
		transform.Translate (amountToMove);

	}
}
