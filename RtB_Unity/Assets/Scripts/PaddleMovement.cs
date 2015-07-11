using UnityEngine;
using System.Collections;

public class PaddleMovement : RtBehaviour {
	
	public Vector3 size;
	private Ray ray;
	private RaycastHit rayCastHit;
	private Vector3 position;
	private Vector3 longPaddle, shortPaddle;
	// Use this for initialization
	void Start () {
		
		//ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		position = new Vector3(0, -3, 0);
		longPaddle = new Vector3 ( 2.5f, 0.2f, 1f);
		shortPaddle = new Vector3 ( .5f, 0.2f, 1f);
	}

	public Vector3 Position
	{
		get 
		{
			return position;
		}
	}

	// Update is called once per frame
	protected override void Update () {
		
		if (!paused)
		{
			// Touch Movement
			if(Input.GetMouseButton(0) )
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out rayCastHit) )
				{
					//Vector3 position = Mathf.Clamp (rayCastHit.point.x, 0f, 10f);
					transform.position = new Vector3(Mathf.Clamp(rayCastHit.point.x, -3.5f, 3.5f), transform.position.y, transform.position.z);
					
				}
			}
			
			//Keyboard Movement
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				if (transform.position.x > -3.5)
				{
					position.x -= .15f;
					transform.position = position;
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				if (transform.position.x < 3.5)
				{
					position.x += .15f;
					transform.position = position;
				}
			}
		}
	}
	
	public void Grow(int size)
	{
		if(size == 1)
		{
			gameObject.transform.localScale = longPaddle;
		}
		if(size == 0)
		{
			gameObject.transform.localScale = shortPaddle;
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent< PaddlePowerUp >() != null )
		{
			
		}
		if (collision.gameObject.GetComponent< PowerUpController >() != null )
		{
			ep.PowerHit();
		}
	}
}
