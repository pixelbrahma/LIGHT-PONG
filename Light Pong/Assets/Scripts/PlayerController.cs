using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float boundY;
	public KeyCode up = KeyCode.W;
	public KeyCode down = KeyCode.S;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		Vector2 temp = new Vector2 (0, 0);
		rb.velocity = temp;
	}

	void Update ()
	{
		Vector2 velocity = rb.velocity;
		if (Input.GetKey (up)) 
		{
			velocity.y = speed;
		}
		else if (Input.GetKey (down)) 
		{
			velocity.y = -speed; 
		}
		else
		{
			velocity.y = 0;
		}
		rb.velocity = velocity;

		Vector2 position = transform.position;
		if (position.y <= -boundY)
		{
			position.y = -boundY;
		}
		else if (position.y >= boundY) 
		{
			position.y = boundY;
		}
		transform.position = position;
	}
}
