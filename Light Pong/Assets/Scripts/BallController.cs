using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour 
{
	public float ballSpeed;
	public float delayTime = 2;

	private Rigidbody2D rb;
	private Vector2 velocity;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		Invoke ("StartBall", delayTime);
	}

	void Update () 
	{
		
	}

	void StartBall()
	{
		float random = Random.Range (0,2);
		float randomAngle = Random.Range (-30, 30);
		if (random < 1) {
			rb.AddForce (new Vector2 (ballSpeed, randomAngle/2));
		} else {
			rb.AddForce (new Vector2 (-ballSpeed, randomAngle/2));
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
			velocity.x = rb.velocity.x;
			velocity.y = (rb.velocity.y / 2.0f) + (collision.collider.attachedRigidbody.velocity.y / 2.0f);
			rb.velocity = velocity;
		}
	}

	void ResetBall()
	{
		velocity = Vector2.zero;
		rb.velocity = velocity;
		transform.position = Vector2.zero;
	}

	void RestartGame()
	{
		ResetBall ();
		Invoke ("StartBall", delayTime);
	}
}
