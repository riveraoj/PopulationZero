using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public int health = 100;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	public void Hurt(int amount)
	{
		health -= amount;
		if(health<=0)
			Destroy(gameObject);
	}
}
