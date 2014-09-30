using UnityEngine;
using System.Collections;

public class Spongy : MonoBehaviour
{
	public GUIStyle myStyle;

	GameObject[] gameObjects;

	float speed = 1.0f;
	int lives = 3;
	int score = 0;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		MoveCharacter();
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 100, 30), "Time: " + Time.time, myStyle);
		GUI.Box(new Rect(500, 10, 100, 30), "Score: " + score);
		GUI.Box(new Rect(600, 10, 100, 30), "Lives: " + lives);
	}

	void MoveCharacter()
	{
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}

	//	TODO: Remove off screen objects
	void RemovalGrime()
	{
		gameObjects =  GameObject.FindGameObjectsWithTag("Grime");
		for(var i = 0 ; i < gameObjects.Length ; i++)
			Destroy(gameObjects[i]);
	}
	
	void RemovalAcid()
	{
		gameObjects =  GameObject.FindGameObjectsWithTag("Acid");
		for(var i = 0 ; i < gameObjects.Length ; i++)
            Destroy(gameObjects[i]);
    }
    
    void OnCollisionEnter2D(Collision2D other)
	{
		switch(other.gameObject.name)
		{
			case "Acid(Clone)":
				lives -= 1;
				if(lives < 1) 
				{
					RemovalAcid();
					RemovalGrime();
                    Time.timeScale = 0;
                }
				Destroy(other.gameObject);
				break;

			case "Grime(Clone)":
				score += 50;
				break;
		}
    }
}

