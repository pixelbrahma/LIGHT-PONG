using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallsScript : MonoBehaviour 
{
	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "Ball") {
			string wall = transform.name;
			GameController.Score (wall);
			collider.gameObject.SendMessage ("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
		}
	}
}
