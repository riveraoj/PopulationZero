using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {
	
	public float moveSpeed = 1;
	public float rotationSpeed = 3;
	public Transform target;
	public Transform myTransform;
	
	void Awake()
	{
		myTransform = transform;
		
	}
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}
	
	void Move()
	{
	
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position
			- myTransform.position), rotationSpeed*Time.deltaTime);
		
		myTransform.position += myTransform.forward * moveSpeed *Time.deltaTime;
		
	}
	
	
}
