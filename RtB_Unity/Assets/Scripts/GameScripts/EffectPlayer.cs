using UnityEngine;
using System.Collections;

public class EffectPlayer : RtBehaviour {

	public AudioClip brickPlop, ballPong, steelDunk, soundBad, soundGood;
	public AudioSource effect;
	public bool playing;

	void Awake()
	{
		if (PlayerPrefs.GetInt("Effects") == 1)
		{
			playing = true;
		}
		else
			playing = false;
		
	}

	protected override void Update()
	{
		if (PlayerPrefs.GetInt("Effects") == 1)
		{
			playing = true;
		}
		else
		{
			playing = false;
		}
	}

	public void BrickBreak()
	{
		if (playing)
		{
			effect.clip = brickPlop;
			effect.PlayOneShot(brickPlop, .45f);
		}
	}

	public void BallHit()
	{
		if (playing)
		{
			effect.clip = ballPong;
			effect.PlayOneShot(ballPong, .45f);
		}
	}

	public void SteelHit()
	{
		if (playing)
		{
			effect.clip = steelDunk;
			effect.PlayOneShot(steelDunk, .48f);
		}
	}

	public void PowerHit()
	{
		if (playing)
		{
			effect.clip = soundGood;
			effect.PlayOneShot(soundGood, .8f);
		}
	}

	public void PowerNoHit()
	{
		if (playing)
		{
			effect.clip = soundBad;
			effect.PlayOneShot(soundBad, .8f);
		}
	}
}
