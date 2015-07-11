using UnityEngine;
using System.Collections;

public class OptionsScene : RtBehaviour {

	private Ray ray;
	private RaycastHit rayCastHit;
	private bool fx, ms;
	public TextMesh mT, fT;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("Music") == 1)
		{
			ms = true;
			mT.text = "Music: On";
		}
		else
		{
			ms = false;
			mT.text = "Music: Off";
		}
		if (PlayerPrefs.GetInt("Effects") == 1)
		{
			fx= true;
			fT.text = "Sound Effects: On";
		}
		else
		{
			fx = false;
			fT.text = "Sound Effects: Off";
		}
	}
	
	protected override void Update () 
	{
		
		
		base.Update();
		if(Input.GetMouseButtonDown(0) )
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayCastHit) )
			{
				PlayerPrefs.SetInt("Played", 1);
				if (rayCastHit.transform.name == "fxPLAY")
				{
					fx = !fx;
					if (fx)
					{
						fT.text = "Sound Effects: On";
						PlayerPrefs.SetInt("Effects", 1);
						ep.playing = true;
						ep.PowerHit();
					}
					else if (!fx)
					{
						ep.PowerNoHit();
						fT.text = "Sound Effects: Off";
						PlayerPrefs.SetInt("Effects", 0);
					}
				}
				else if (rayCastHit.transform.name == "msPLAY")
				{
					ms = !ms;

					if (ms)
					{
						mT.text = "Music: On";
						PlayerPrefs.SetInt("Music", 1);
						mp.playing = true;
					}
					else if (!ms)
					{
						mp.playing = false;
						mT.text = "Music: Off";
						PlayerPrefs.SetInt("Music", 0);
					}
					
				}
				else if (rayCastHit.transform.name == "ClearPlay")
				{
					mT.text = "Music: On";
					PlayerPrefs.SetInt("Music", 1);
					mp.playing = true;
					fT.text = "Sound Effects: On";
					PlayerPrefs.SetInt("Effects", 1);
					ep.playing = true;
					fx = ms = true;
					PlayerPrefs.SetInt("best", 0);
					PlayerPrefs.SetInt("Played", 0);
					PlayerPrefs.SetInt("gamesPlayed", 0);
					ep.PowerNoHit();
				}

				else if (rayCastHit.transform.name == "playPLAY")
				{
					Application.LoadLevel("Level1");
					//s.NextLevel(1);
					
				}
				else if (rayCastHit.transform.name == "menuPLAY")
				{
					Application.LoadLevel("Menu");
					//s.NextLevel(1);
					
				}
			}
		}



		
	}
}
