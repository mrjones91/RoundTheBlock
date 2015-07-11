using UnityEngine;
using System.Collections;

public class PowerUpController : RtBehaviour {
	
	protected Vector3 position;
	
	public virtual void Awake()
	{
		gameObject.SetActive(false);
		
	}
	
	public virtual void Start () 
	{
		position = gameObject.transform.position;
	}

	protected override void Update () 
	{
		if (!paused)
		{
			if ( gameObject.activeSelf )
			{
				position.y -= .01f;
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
				score.AddScore(50f);
			}
		}
	}
	protected virtual void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent("BallMovement"))
		{

		}
		ep.PowerHit();
	}
	

}
