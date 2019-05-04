using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GUISkin layout;
	public float winScore;

	GameObject ball;
	private static int player1Score;
	private static int player2Score;

	void Start () 
	{
		player1Score = 0;
		player2Score = 0;
		ball = GameObject.FindGameObjectWithTag("ball");
	}

	void Update () 
	{
		
	}

	public static void Score(string wall)
	{
		if (wall == "RightWall") {
			player1Score++;
		} else {
			player2Score++;
		}
	}

	void OnGUI()
	{
		GUI.skin = layout;
		GUI.Label (new Rect (Screen.width/2 - 250, 20, 100, 100),"" + player1Score);
		GUI.Label (new Rect (Screen.width/2 + 250, 20, 100, 100),"" + player2Score);

		if (GUI.Button (new Rect (Screen.width/2 - 100, 10, 200, 30), "RESTART")) {
			player1Score = 0;
			player2Score = 0;
			ball.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
		}

		if (player1Score == winScore) {
			GUI.Label (new Rect (Screen.width / 4, Screen.height/4, Screen.width / 2, Screen.height/2), " PLAYER 1 VICTORY .. !! ");
			ball.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
		else if (player2Score == winScore) {
			GUI.Label (new Rect (Screen.width / 4, Screen.height/4, Screen.width / 2, Screen.height/2), " PLAYER 2 VICTORY .. !! ");
			ball.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}
}
