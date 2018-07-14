using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 50.0F;
	
	public float jumpForce = 100.0F;
	
	
	private Rigidbody rb;
	
	private bool isGrounded;
	

	void Start () {
		isGrounded = true;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
		float straffe = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		
		if(Input.GetButtonDown("Jump") && isGrounded){
			rb.AddForce((new Vector3(0.0F, 2.0F, 0.0F)) * jumpForce , ForceMode.Impulse);
		}
		
		transform.Translate(straffe,0,translation);
		
	}
	void OnCollisionExit(){
		isGrounded=false;
	}
	void OnCollisionStay(){
		isGrounded = true;
	}
}
