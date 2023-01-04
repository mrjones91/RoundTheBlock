using UnityEngine;
using System.Collections;

public class SafetyPowerUp : PowerUpController {
	
	public GameObject safebar;
	private Quaternion rotation;
	
	
	public override void Awake()
	{
		gameObject.SetActive(false);

	}
	
	public override void Start ()
	{
		base.Start ();
		
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
			
			if (GetComponent<Collider>().bounds.Intersects(paddle.GetComponent<Collider>().bounds))
			{
				Destroy (gameObject);
				ep.PowerHit();
				score.AddScore(15);
				GameObject bar = (GameObject)Instantiate(safebar, new Vector3(-1f, -4f, 0f) , Quaternion.identity );
			}
		}
	
	}

	protected override void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent("BallMovement"))
		{
			
		}

	}
	
	
	

	
}
