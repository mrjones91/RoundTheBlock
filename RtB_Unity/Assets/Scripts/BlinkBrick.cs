using UnityEngine;
using System.Collections;

public class BlinkBrick : BrickScript{
	public int bSpeed;
	bool displayed;
	float[] speeds;

	protected override void Start () 
	{
		base.Start();
		speeds = new float[5];
		speeds[0] = .3f;
		speeds[1] = .4f;
		speeds[2] = .5f;
		speeds[3] = .6f;
		speeds[4] = .7f;

		InvokeRepeating("Blink", 1f, speeds[bSpeed]);
	}
	
	void Blink()
	{
		displayed = !displayed;
		
		if (displayed)
			gameObject.SetActive(true);
		else
			gameObject.SetActive(false);
	}
}
