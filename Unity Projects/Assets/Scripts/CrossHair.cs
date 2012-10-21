using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {
	
	public Texture image;

	void OnGUI() 
	{
 		 GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, image.width, image.height), image);
	}
}


