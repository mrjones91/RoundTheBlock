using UnityEngine;
using System.Collections;

public class BrickScript : RtBehaviour {

	public int type;
	float points;
	public MeshRenderer mesh;
	public PowerUpController power;
	
	//public MainGame mainGameScript;
	protected virtual void Start () {
		
		
		//mesh = (MeshRenderer)(gameObject.GetComponent("Mesh"));
		
		
		// Set point to BrickType...
		switch(type)
		{
		case 1:
			//figure out enums
			//set color to Blue
			//points = BrickType.
			//Color poo = new Color(228, 130 , 228);
			mesh.material.color = Color.blue;
			points = 10;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 2:
			//set color to Red
			mesh.material.color = Color.red;
			points = 10;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 3:
			//set color to Yellow
			mesh.material.color = Color.yellow;
			points = 10;
			PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 4:
			//set color to Green
			mesh.material.color = Color.green;
			points = 10f;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 5:
			//set color to Purple
			mesh.material.color = new Color(128, 0, 128);
			points = 10;
			break;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );

		case 6:
			//set color to Brown
			Color brown = new Color(100, 100, 100, 50);
			mesh.material.color = brown;
			points = 10;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 7:
			//set color to White
			mesh.material.color = Color.white;
			points = 20;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break; 
		case 10:
			mesh.material.color = Color.gray;
			points = 0;
			break;
		case 11:
			mesh.material.color = Color.black;
			points = 10;
			break;
		case 12: //Salmon Pink
			mesh.material.color = new Color(255, 145, 164, 255);
			points = 10;
			break;
		case 13: //Cream
			mesh.material.color = new Color(255, 253, 208);
			points = 10;
			break;
		case 14: //Crimson
			mesh.material.color = new Color(220, 20, 60);
			points = 10;
			break;
		case 15: //Old Gold
			mesh.material.color = new Color (207, 181, 59);
			points = 10;
			break;
		case 16: //royal blue
			break;
		default:
			mesh.material.color = new Color(50, 50, 50);
			points = 100;
			Debug.Log("Fix " + gameObject.name + " you dummy!");
			break;
			
		}
	}
	
	
	
	void OnCollisionEnter(Collision col)
	{
		
		Destroy (gameObject);
		score.AddScore(points);
		game.AddBrick(1);
		if (power != null)
		{
			power.gameObject.SetActive(true);
		}

	}
	

}

public enum BrickType{
	Blue = 1,
	Red = 1,
	Yellow = 1,
	Green = 1, //1.5
	Purple = 1, //1.5
	Brown = 2,
	White = 2,
}
