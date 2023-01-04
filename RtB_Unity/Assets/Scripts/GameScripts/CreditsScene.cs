using UnityEngine;
using System.Collections;

public class CreditsScene : RtBehaviour {

	private Ray ray;
	private RaycastHit rayCastHit;

	public TextMesh Contact, Name, Thank;
	// Use this for initialization
	void Start () 
	{
		Contact.text = "@TSU_TheBlock\n#TSUgame #TSU #HBCU";
		Name.text = "Created by Daniel Jones";
		Thank.text = "Thanks for Playing!";
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		if(Input.GetMouseButtonDown(0) )
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayCastHit) )
			{
				if (rayCastHit.transform.name == "#Hash")
				{
					ep.PowerHit();
					Application.OpenURL("https://twitter.com/TSU_TheBlock");
				}

				if (rayCastHit.transform.name == "Menu1")
				{
					ep.PowerHit();
					Application.LoadLevel("Menu");
				}

				if (rayCastHit.transform.name == "tsuBanner")
				{
					ep.PowerHit();
					Application.OpenURL("https://www.tnstate.edu/");
				}

				if (rayCastHit.transform.name == "Blog")
				{
					ep.PowerHit();
					Application.OpenURL("http://wayofthejones.blogspot.com/");
				}
				if (rayCastHit.transform.name == "Email")
				{
					ep.PowerHit();
					Application.OpenURL("mailto:dj@dij.io");
				}
				if (rayCastHit.transform.name == "Tweet")
				{
					ep.PowerHit();
					Application.OpenURL ("https://twitter.com/intent/tweet?&text=Scored%20" + PlayerPrefs.GetInt("best") + "%20points%20on%20The%20NEW%20@TSU_TheBlock%20from%20@djstrongmane!!!%20&hashtags=TSUgame,HBCU,RepYoHBCU,TSU");
				}
			}
		}
	}
}
