using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	
	public float speed = 0.03F;
	
	public Transform playerPosition;
	
	void FixedUpdate () {
		transform.position = Vector3.Lerp(transform.position, playerPosition.position, Time.deltaTime * speed);
	}
}
