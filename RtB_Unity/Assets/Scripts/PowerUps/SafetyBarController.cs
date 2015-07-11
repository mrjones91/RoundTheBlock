using UnityEngine;
using System.Collections;

public class SafetyBarController : RtBehaviour {

	private float timeLimit, hitLimit;
	private Color[] strength;
	// Use this for initialization
	void Start () {
		timeLimit = 10;
		hitLimit = 0;
		strength = new Color[3];
		strength[0] = Color.green;
		strength[1] = Color.yellow;
		strength[2] = Color.red;
		renderer.material.color = strength[(int)hitLimit];
	}
	
	// Update is called once per frame
	protected override void Update () {
		if (!paused)
		{
			if (gameObject.activeSelf)
			{
				timeLimit -= Time.deltaTime;
			}
		}
		
		if (timeLimit <= 0 || hitLimit > 2)
		{
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			if (hitLimit < 3)
			{
				hitLimit += 1;
				if (hitLimit <=2)
				{
					renderer.material.color = strength[(int)hitLimit];
				}
			}
			
		}
		
	}
}
