using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed = 5;
	public float jumpForce = 1000;
	bool isTouchingGround;
	public float lookSpeed = 30;
	public float throwPower = 1000;
	public Object ball;
	
	// Use this for initialization
	void Start () {
		isTouchingGround = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		keyMovement();
		MouseLook();
	}
	
	void keyMovement()
	{
		if(Input.GetKey (KeyCode.W))
		{
			transform.Translate(moveSpeed*Time.deltaTime*transform.forward,Space.World);
		}
		
		if(Input.GetKey (KeyCode.S))
		{
			transform.Translate(-moveSpeed*Time.deltaTime*transform.forward,Space.World);
		}
		
		if(Input.GetKey (KeyCode.D))
		{
			transform.Translate(moveSpeed*Time.deltaTime*transform.right,Space.World);
		}
		
		if(Input.GetKey (KeyCode.A))
		{
			transform.Translate(-moveSpeed*Time.deltaTime*transform.right,Space.World);
		}
		
		if(Input.GetKey (KeyCode.Space) && isTouchingGround)
		{
			rigidbody.AddForce(Vector3.up*jumpForce);
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			GameObject newBall = Instantiate(ball,transform.position+transform.forward*2,transform.rotation) as GameObject;
			
			newBall.rigidbody.AddForce(transform.forward*throwPower);
		}
		
	}
	
	void MouseLook()
	{
		transform.Rotate(Vector3.up,lookSpeed*Time.deltaTime*Input.GetAxis("Mouse X"),Space.World);
		transform.Rotate (Vector3.right,-lookSpeed*Time.deltaTime*Input.GetAxis("Mouse Y"));
	}
	
	//Whenever collider touches any other colliders this function will be called
	void OnCollisionEnter(Collision colliInfo)
	{
		isTouchingGround = true;	
	}
	
	void OnCollisionExit(Collision colliInfo)
	{
		isTouchingGround = false;
	}
}


// use .fbx to include models that have animation. No animation is fine with 3DS
