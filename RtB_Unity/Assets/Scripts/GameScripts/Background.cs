using UnityEngine;
using System.Collections;

public class Background : RtBehaviour {

	public Texture[] frames;
	public float FPS, alpha;
	private float secondsToWait, offset;
	private bool inBounds;
	private int currentFrame;
	private Vector3 force;
	Color bg;


	void Awake()
	{
		bg = Color.white;
		bg.a = alpha;
	}
	void Start () 
	{
		//scrollSpeed = 0.5f;
		//xOffset = yOffset = Time.time * scrollSpeed;
		currentFrame = 0;
		secondsToWait = 1/FPS;
		if (frames.Length > 0)
		{
			GetComponent<Renderer>().material.mainTexture = frames[currentFrame];
		}
		GetComponent<Renderer>().material.color = bg;
		
		StartCoroutine(Animate());
		inBounds = true;
		
		force = new Vector3(50f, 80f, 0f);
		//if (gameObject.name != "Cube")
		//{
		//	GetComponent<Rigidbody>().velocity = force;
			
		//}

	}
	
	protected override void Update()
	{
		if (gameObject.name != "Cube")
		{
			//Scroll();
		}
		if (bg.a != alpha)
		{
			bg.a = alpha;
		}
		//xOffset += Time.deltaTime;
		//yOffset += Time.deltaTime;
	}
	
	void Scroll()
	{
		//fix this shit. ugh
		if (inBounds)
		{
			//x = Mathf.Clamp(xOffset, 7f, -7f);
			//y = Mathf.Clamp(yOffset, 11f, -8f);
			//gameObject.transform.position = new Vector3(x, y, 12);
			//print ("X: " + x);
			//print ("Y: " + y);
			
		}
		
	}
	void OnCollisionEnter(Collision col)
	{
		//if (col.transform.position.x > GetComponent<Rigidbody>().transform.position.x)
		//	{
				
		//		GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.VelocityChange);
				
		//	}
		//	else if (col.transform.position.x < GetComponent<Rigidbody>().transform.position.x)
		//	{
				
		//		GetComponent<Rigidbody>().AddForce(Vector3.right, ForceMode.VelocityChange);
		//	}
		//	if (col.transform.position.y > GetComponent<Rigidbody>().transform.position.y)
		//	{
		//		GetComponent<Rigidbody>().AddForce(Vector3.down);
		//		//rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
		//	}
		//	else if (col.transform.position.y < GetComponent<Rigidbody>().transform.position.y)
		//	{
		//		GetComponent<Rigidbody>().AddForce(Vector3.up);
		//		//rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
		//	}
	}
	IEnumerator Animate()
	{
				
		yield return new WaitForSeconds(secondsToWait);

		if (currentFrame == frames.Length - 1)
		{
			currentFrame = 0;
		}
		else
			currentFrame++;
		
		GetComponent<Renderer>().material.mainTexture = frames[currentFrame];
		
		StartCoroutine(Animate());

	}

}
