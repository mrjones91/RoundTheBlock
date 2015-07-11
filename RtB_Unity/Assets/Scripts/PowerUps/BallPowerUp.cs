using UnityEngine;
using System.Collections;

public class BallPowerUp : PowerUpController {

	public bool speed;
	private Vector3 accel;
	private int spd;

	public override void Start ()
	{
		base.Start ();
		if (speed)
		{
			spd = 1;
			accel = new Vector3(4.5f, 7f, 0f);
		}
		else
		{
			spd = -1;
			accel = new Vector3(2f, 3f, 0f);
		}
	}

	protected override void Update ()
	{
		if (!paused)
		{
			if ( gameObject.activeSelf )
			{
				position.y -= .10f;
				gameObject.transform.position = position;
			}
			
			if (position.y < -4f)
			{
				Destroy ( gameObject );
			}
			
			if (collider.bounds.Intersects(paddle.collider.bounds))
			{
				Destroy (gameObject);
				ep.PowerHit();
				ball.spd = spd;
				if (speed)
				{
					score.AddScore(30);
				}
				else
				{
					score.AddScore(35);
				}

			}
		}
	}

	protected override void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent("BallMovement"))
		{
			
		}
		ep.PowerHit();
	}


}
