using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	private int score, hiScore, level, bestScore;
	
	
	public TextMesh GuiScore, GuiLives;
	
	
	// Use this for initialization
	void Start () {
		
		
		score = PlayerPrefs.GetInt("Score");
		level = PlayerPrefs.GetInt("currentlvl");
		bestScore = PlayerPrefs.GetInt("best");
		GuiScore.text = "Score: " + score;

		
	}
	
	// Update is called once per frame
	void Update () {
		GuiLives.text = "Lives: " + PlayerPrefs.GetInt("lives");
		if (score > PlayerPrefs.GetInt("highScore"))
			{
				PlayerPrefs.SetInt("highScore", score);
			}
		else if (score > PlayerPrefs.GetInt("best"))
		{
			PlayerPrefs.SetInt("best", score);
		}
	}
	
	public void AddScore(float points) {

		//points *= ( (level + 1) * 10);

		score += (int)points;
		//Debug.Log("score = " + score + " points = " + points);
		GuiScore.text = "Score: " + score.ToString();
		PlayerPrefs.SetInt("Score", score);
	}
	
	
	
	
}
