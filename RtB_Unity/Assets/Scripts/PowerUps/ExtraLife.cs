﻿using UnityEngine;
using System.Collections;

public class ExtraLife : PowerUpController {

	int life;

	protected override void Update () 
	{
		if (!paused)
		{
			if ( gameObject.activeSelf )
			{
				life = PlayerPrefs.GetInt("lives") + 1;
				position.y -= .10f;
				gameObject.transform.position = position;
			}
			
			if (position.y < -4f)
			{
				Destroy ( gameObject );
			}
			
			if (GetComponent<Collider>().bounds.Intersects(paddle.GetComponent<Collider>().bounds))
			{
				Destroy (gameObject);
				ep.PowerHit();
				PlayerPrefs.SetInt("lives", life);
			}
		}
	}
}
