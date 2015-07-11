using UnityEngine;
using System.Collections;

public class PaddlePowerUp : PowerUpController {
	
	public bool longer;
	
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
				
				if (longer)
				{
					ep.PowerHit();
					paddle.Grow(1);
					score.AddScore(20);
				}
				else if (!longer)
				{
					ep.PowerNoHit();
					paddle.Grow(0);
					score.AddScore(60);
				}
			}
		}
	
	}

	protected override void OnCollisionEnter(Collision col)
	{

		if (longer)
		{
			ep.PowerHit();
		}
		else
		{
			ep.PowerNoHit();
		}
	}

}
