using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public float lifeSpan = 10;
	float currLifeSpan;

	// Use this for initialization
	void Start () {
		currLifeSpan = lifeSpan;
	//Physics.IgnoreCollision(GameObject.Find("Camera").collider,collider);
	}
	
	// Update is called once per frame
	void Update () {
		currLifeSpan -= Time.deltaTime;
		if(currLifeSpan<=0)
			Destroy(gameObject);
	}
	
	void OnCollisionEnter(Collision colliInfo)
	{
		if(colliInfo.gameObject.name.Contains("Enemy"))
		{
			colliInfo.gameObject.SendMessage("Hurt",10);
			Destroy(gameObject);
		}
	}
	
}
