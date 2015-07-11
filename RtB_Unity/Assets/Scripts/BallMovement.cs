using UnityEngine;
using System.Collections;

public class BallMovement : RtBehaviour 
{
	public Vector3 acceleration;
	private Vector3 decel;
	private Vector3 force;
	private float stuckX, stuckY;
	public int spd;

	
	void Awake() {
 
		//speed = 2;

		spd = 0;

		//constantForce.force = new Vector3(-.5f, -1.5f, 0f);
		
		//InvokeRepeating("IncreaseBallVelocity", 2, 1f);
	}
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		if (!paused)
		{
			if (transform.position.y < -6 || transform.position.x > 3.08 || transform.position.x < -3.08)
			{
				game.GameOver();
			}

			//rigidbody.transform.position += new Vector3(0, .05f);
			//rigidbody.velocity += ;
			if (Mathf.Abs(stuckX) == Mathf.Abs(rigidbody.velocity.x) )
			{
				UnStick();
			}
			else if (Mathf.Abs(stuckY) == Mathf.Abs(rigidbody.velocity.y) )
			{
				UnStick();
			}

			if (rigidbody.velocity.x < 1.8f || rigidbody.velocity.y < 2.8f)
			{
				InvokeRepeating("Moving", 0f, 10f);
			}

		}
		
	}

	void Moving()
	{
		switch(spd)
		{
		case -1: force = new Vector3(2f, 3f, 0f);
			break;
		case 0: force = new Vector3(3f, 5f, 0f);
			break;
		case 1: force = new Vector3(4.5f, 7f, 0f);
			break;
		}

		if( ( (rigidbody.velocity.x < 0) && (force.x > 0)) || ( (rigidbody.velocity.x > 0) && (force.x < 0) ) )
		{
			force.x *= -1;
		}
		if( ( (rigidbody.velocity.y < 0) && (force.y > 0)) || ( (rigidbody.velocity.y > 0) && (force.y < 0) ) )
		{
			force.y *= -1;
		}
		//force = new Vector3(3f, 5f, 0f);
		rigidbody.velocity = force;
	}


	void Accelerate()
	{
		rigidbody.velocity += acceleration;
	}

	void Decelerate()
	{
		rigidbody.velocity = force;
	}

	public void Accelerate(Vector3 accel)
	{
		if( ( (rigidbody.velocity.x < 0) && (accel.x > 0)) || ( (rigidbody.velocity.x > 0) && (accel.x < 0) ) )
		{
			accel.x *= -1;
		}
		if( ( (rigidbody.velocity.y < 0) && (accel.y > 0)) || ( (rigidbody.velocity.y > 0) && (accel.y < 0) ) )
		{
			accel.y *= -1;
		}
		rigidbody.velocity = accel;
		acceleration = accel;
	}

	void UnStick()
	{
		rigidbody.AddForce(0f, -1f, 0f);
		rigidbody.AddForce(-1f, 0f, 0f);
	}

	void UnStick(int axis)
	{
		if (axis == 0)
		{
			rigidbody.AddForce(0f, -1f, 0f);
			//print ("YYYY");
		}
		else if (axis == 1)
		{
			rigidbody.AddForce(-0.5f, 0f, 0f);
			//print ("XXXX");
		}
	}
	void OnCollisionEnter(Collision col)
	{
		
		stuckX = rigidbody.velocity.x;
		stuckY = rigidbody.velocity.y;
		//print (rigidbody.velocity);
		if (col.gameObject.GetComponent<SteelBrick>())
		{
			ep.SteelHit();
		}

		else if (col.gameObject.GetComponent<BrickScript>())
		{
			ep.BrickBreak();
		}
		else
		{
			ep.BallHit();
		}
	}
	
	protected override void OnPauseGame ()
	{

		//force = rigidbody.velocity;
		//rigidbody.velocity = Vector3.zero;
		base.OnPauseGame ();
		CancelInvoke("Moving");
	}

	public void OnStartGame()
	{
		paused = true;
		gameObject.collider.isTrigger = true;
		CancelInvoke("Moving");
	}

	public void OnRelease()
	{
		paused = false;
		gameObject.collider.isTrigger = false;
		//acceleration = new Vector3(.15f, .2f, 0);
		force = new Vector3(3f, 5f, 0f);
		rigidbody.velocity = force;
		InvokeRepeating("Moving", 1, .25f);
	}

	protected override void OnResumeGame ()
	{
		base.OnResumeGame ();
		InvokeRepeating("Moving", 1, .25f);
		//rigidbody.AddForce(force);
	}
	
	

		
	
}
