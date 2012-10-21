using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public Object Ball;
	public float throwPower = 1000;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fire();
	}
	
	void Fire()
	{
		if(Input.GetMouseButtonDown(0))
			{
				GameObject newBall = Instantiate(Ball,transform.position+transform.forward*2,transform.rotation) as GameObject;
			
				newBall.rigidbody.AddForce(transform.forward*throwPower);
			}
	}
}
