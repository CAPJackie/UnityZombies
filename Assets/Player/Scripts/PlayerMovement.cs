using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	static Animator anim;
	
	public float speed = 50.0F;
	
	public float jumpForce = 100.0F;
	
	public float life;
	
	public Transform respawn;
	
	
	private Rigidbody rb;
	
	private bool isGrounded;
	

	void Start () {
		anim = GetComponent<Animator>();
		isGrounded = true;
		life = 100;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(this.life);
		if(this.life <= 0){
			StartCoroutine(_Death());
		}
		
		if(Input.GetButtonDown("Punch")){
			anim.SetBool("isPunching", true);
		}
		
		float translation = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
		float straffe = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		if(translation == 0 && straffe == 0){
			anim.SetBool("isIdle",true);
			anim.SetBool("isRunning", false);
		}
		else{
			anim.SetBool("isIdle",false);
			anim.SetBool("isRunning", true);
		}
		
		if(Input.GetButtonDown("Jump") && isGrounded){
			anim.SetBool("isJumping",true);
			rb.AddForce((new Vector3(0.0F, 2.0F, 0.0F)) * jumpForce , ForceMode.Impulse);
		}
		
		transform.Translate(straffe,0,translation);
		
	}
	void OnCollisionExit(){
		isGrounded=false;
	}
	void OnCollisionStay(){
		anim.SetBool("isJumping",false);
		isGrounded = true;
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Enemy")){
			life -= 10;
		}
	}
	
	
	public IEnumerator _Death(){
		anim.SetBool("isDead",true);
        yield return new WaitForSeconds(4.6F);
		anim.SetBool("isDead",false);
        this.transform.position = respawn.position;
        this.life = 100;
		
    }
}
