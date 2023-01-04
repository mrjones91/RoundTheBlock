using UnityEngine;
using System.Collections;

public class PauseGUI : RtBehaviour {
	
	public TextMesh text, hiScore, menu1, menu2;
	
	void Awake()
	{
		text.text = hiScore.text = "";
		hiScore.text = "";
		menu1.text = "";
		menu1.GetComponent<Collider>().isTrigger = true;
		menu2.text = "";
		menu2.GetComponent<Collider>().isTrigger = true;
		//renderer.isVisible = false;
	}
	protected override void Update ()
	{
		base.Update ();

	}
	protected override void OnPauseGame ()
	{
		base.OnPauseGame ();
		paused = true;
		text.text = "Paused";
		hiScore.text = "Your Best: " + PlayerPrefs.GetInt ("best");
		hiScore.transform.position = new Vector2(-1.4f, 1.7f);
		menu1.text = "Quit to Menu?";
		menu1.transform.position = new Vector3(-1.397773f, -0.9863482f, -.5f);
		menu1.GetComponent<Collider>().isTrigger = false;
		menu2.text = "";
		menu2.transform.position = new Vector3(-1.397773f, -0.9863482f, 0f);
		menu2.GetComponent<Collider>().isTrigger = true;
		//renderer.isVisible = true;
	}
	
	protected override void OnResumeGame ()
	{
		base.OnResumeGame();
		end = paused = false;
		text.text = "";
		hiScore.text = "";
		menu1.text = "";
		menu1.transform.position = new Vector3(-1.397773f, -0.9863482f, 0f);
		menu1.GetComponent<Collider>().isTrigger = true;
		menu2.text = "";
		menu2.transform.position = new Vector3(-1.397773f, -0.9863482f, 0f);
		menu2.GetComponent<Collider>().isTrigger = true;
		//renderer.isVisible = false;
	}

	protected override void OnEndGame ()
	{
		base.OnResumeGame();
		end = true;
		game.SendMessage("OnEndGame");
		menu1.GetComponent<Collider>().isTrigger = true;
		menu2.transform.position = new Vector3(-1.397773f, -0.9863482f, 0f);
		menu2.GetComponent<Collider>().isTrigger = false;
		text.text = "Game Over";
		text.transform.localScale = new Vector3(0.14327f, 0.14327f, 0.14327f);
		text.transform.position = new Vector3(-2.719229f, 0f, 0f);

		hiScore.alignment = TextAlignment.Center;
		hiScore.transform.position = new Vector2(-1.6f, 1.737249f);
		hiScore.text = "Score: " + PlayerPrefs.GetInt("Score") + "\nYour Best: " + PlayerPrefs.GetInt("best");

		menu2.text = "Try Again?";
		menu2.transform.position = new Vector3(-1.397773f, -0.9863482f, -.5f);
		menu2.transform.position = new Vector3(-1.159526f, -0.9863482f, 0);
		//mp.audio.Stop();
		mp.GetComponent<AudioSource>().clip = win;
		//mp.audio.Play ();
		//renderer.isVisible = false;
	}
}
