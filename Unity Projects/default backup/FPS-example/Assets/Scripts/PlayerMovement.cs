using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	// Variables
	//public makes changeable in inspector
	public float moveSpeed = 5; //possibly m/s
	public float jumpForce = 1000; //Newtons
	bool isTouchingGround;
	public float lookSpeed = 30;
	public float throwPower = 1000;
	public Object ball;
	
	// Use this for initialization
	void Start () 
	{
		isTouchingGround=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		KeyMovement();
		MouseLook();
	}
	
	void KeyMovement()
	{	
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(moveSpeed * Time.deltaTime * transform.forward, Space.World);
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(-moveSpeed * Time.deltaTime * transform.forward, Space.World);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(-moveSpeed * Time.deltaTime * transform.right, Space.World);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(moveSpeed * Time.deltaTime * transform.right, Space.World);
		}
		if(Input.GetKey(KeyCode.Space)&& isTouchingGround)
		{
			rigidbody.AddForce(Vector3.up*jumpForce);
		}
		//GetMouseButton - holding
		//GetMouseButtonDown - press, release, then press again
		//0=left mouse button
		if(Input.GetMouseButtonDown(0))
		{
			GameObject newBall = Instantiate(ball, transform.position + transform.forward * 2, transform.rotation) as GameObject;
			//"as GameObject" = type-casting in C#
			
			newBall.rigidbody.AddForce(transform.forward*throwPower);
		}
	}
	
	void MouseLook()
	{
		//only use Space.World in one, since up is always up, but right for a player is diff. than world
		transform.Rotate(Vector3.up, lookSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), Space.World);
		transform.Rotate(Vector3.right, -lookSpeed * Time.deltaTime * Input.GetAxis("Mouse Y"));
	}
	
	//OnCollisionEnter, OnCollisionExit, OnCollisionStay
	//there is also OnTrigger*. Trigger from capsule collider
	void OnCollisionEnter(Collision colliInfo)
	{
		isTouchingGround = true;
	}
	
	void OnCollisionExit(Collision colliInfo)
	{
		isTouchingGround = false;
	}
}
