using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public Rigidbody2D cannonBall;
	float power = 30.0f;


	void OnGUI()
	{
		GUI.Box(new Rect(10,10,100,30), "Power: " + power);
	}
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate()
	{
		Cannonballs();
	}

	void Cannonballs()
	{
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
		{
			if (power <= 39)
			{
				power += 1;
			}
		}

		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
		{
			if (power >= 21)
			{
				power -= 1;
			}
		}

		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			SpawnCannonBalls();
		}
	}

	void SpawnCannonBalls()
	{
		var cannonBallInstance = (Rigidbody2D)Instantiate(cannonBall, new Vector3(-84,-40,72), Quaternion.Euler(new Vector3(0,0,0)));
		cannonBallInstance.transform.Rotate(0,0,54);
		cannonBallInstance.velocity = new Vector2(power,power);
	}
}
