using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGame : RtBehaviour {
	
	
	
	//private GameObject ball;
	//private int score = 0;
	void Awake(){
		Text GuiScore;
		Text GuiHighScore;
		//ball = GameObject.Find("Ball");
	}
	//public int speed = 2;
	// Use this for initialization
	void Start () {

	}
	

	
	public void UpdateScore(int points)
	{
		//score += 1;
		//GuiScore.text = "Score: " + score.ToString();
		
	}
	
	public void GameOver()
	{
		
//		if (score > PlayerPrefs.GetInt("highScore"))
//		{
//			PlayerPrefs.SetInt("highScore", score);
//		}
//		Debug.Log(PlayerPrefs.GetInt("highScore"));
//		GuiHighScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");
//		Application.LoadLevel("Menu");
	}
}
