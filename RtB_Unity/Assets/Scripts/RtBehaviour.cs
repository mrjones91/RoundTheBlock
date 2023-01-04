using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RtBehaviour : MonoBehaviour {
	
	public Text GuiScore;
	public Text GuiHighScore;
	
	public BlockGame game;
	public ScoreScript score;
	public PaddleMovement paddle;
	public BallMovement ball;
	public MusicPlayer mp;
	public EffectPlayer ep;
	public AudioClip win;
	//private GameObject menuB;

	private bool sent;
	
	protected PowerUpController powerUp;
	protected BrickScript brick;
	protected bool paused, end;

	private Ray ray;
	private RaycastHit rayCastHit;
	
	public virtual bool Paused
	{
		get
		{
			return paused;
		}
		set
		{
			paused = value;
		}
	}
	public virtual bool End
	{
		get
		{
			return end;
		}
	}
	// Use this for initialization
	void Start () {
		//menu = GameObject.Find("Menu");


		end = false;
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
		if ( Input.GetKeyDown(KeyCode.Escape) )
		{
			if (Application.loadedLevelName=="Menu")
			{
				BackButton();
			}
			else if (Application.loadedLevelName == "Options" || Application.loadedLevelName == "Credits")
			{
				Application.LoadLevel("Menu");
			}
			else if (Application.loadedLevelName=="Level1" || Application.loadedLevelName=="Level2" || Application.loadedLevelName=="Level3")
			{
				if (end)
				{
					Application.LoadLevel("Menu");
				}
				else
				{
					Menu ();
				}
			}

		}
		if ( Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Space) )
		{
			Menu();
		}

		//if (

		if (game)
		{
			if (game.Lives < 0)
			{
				OnEndGame();
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (paused == true || end == true)
				{
					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out rayCastHit) )
					{
						if (rayCastHit.transform.name == "Menu1" && (rayCastHit.transform.GetComponent<Collider>().isTrigger == false) )
						{

							OnResumeGame();
							Application.LoadLevel("Menu");
														
						}
						else if (rayCastHit.transform.name == "Menu2" && (rayCastHit.transform.GetComponent<Collider>().isTrigger == false))
						{
							OnResumeGame();
							PlayerPrefs.SetInt("lives", 2);
							PlayerPrefs.SetInt("Score", 0);
							PlayerPrefs.SetInt("currentLvl", 1);
							Application.LoadLevel("Level1");
							
						}
					}
				}
			}
		}



	}
	
	protected virtual void BackButton()
	{
		PlayerPrefs.SetInt("Played", 1);
		Application.Quit();
	}
	
	protected virtual void Menu()
	{
		//GameObject[] objects = {GameObject.Find("Ball"), GameObject.Find("Paddle"), 
		//	GameObject.Find ("Pause GUI"), GameObject.Find ("GuiHighScore")};
		//
		//for (int i = 0; i < objects.Length; i++)
		//{

		//can get rid of sent and just use paused, but not sure if want
			if (!sent)
			{
			OnPauseGame();
				//objects[i].SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				//Debug.Log(objects[i].name + "Paused");
			}
			else if (sent)
			{
			OnResumeGame();
				//objects[i].SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
			}
		//}
	}
	
	protected virtual void OnPauseGame()
	{
		sent = true;
		paused = true;
		Time.timeScale = 0;
	}
	protected virtual void OnResumeGame()
	{
		sent = false;
		paused = false;
		end = false;
		Time.timeScale = 1;
	}
	protected virtual void OnEndGame()
	{
		//sent = false;
		end = true;
		paused = true;
		Time.timeScale = 1;

	}
}
