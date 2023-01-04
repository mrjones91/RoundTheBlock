using UnityEngine;
using System.Collections;

public class SplashScreen : RtBehaviour {
	
	private float timer;
	private float alpha;
	private Color fade;
	
	void Awake ()
	{
		timer = 3.5f;
		alpha = .2f;
		fade = new Color(0, 0, 0, alpha);
		GetComponent<Renderer>().material.color = fade;
	}
	
	void Start () {
	
	}
	
	
	protected override void Update () 
	{
		base.Update();
		timer -= Time.deltaTime;
		alpha -= .2f;
		fade.a = alpha;
		GetComponent<Renderer>().material.color = fade;
		
		if (timer <= 0  || Input.GetMouseButton(0))
		{
			Application.LoadLevel("Menu");
		}
		
	}
}
