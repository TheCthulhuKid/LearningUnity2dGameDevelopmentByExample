using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 
{
	public Rigidbody2D obstacle;
	public GameObject ninjaObj;

	float speed = -3.0f;

	// Use this for initialization
	void Start()
	{
		Invoke("SpawnObstacle", 3);
	}
	
	// Update is called once per frame
	void Update() 
	{
	
	}

	void SpawnObstacle()
	{
		var obstacleInstance = (Rigidbody2D)Instantiate(obstacle, new Vector3(10,Random.Range(-4, 0),0), Quaternion.Euler(new Vector3(0,0,0)));

		obstacleInstance.name = "Obstacle(Clone)";
		obstacleInstance.velocity = new Vector2(speed, 0);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name=="Ninja")
		{
			Time.timeScale = 0;
			Destroy(gameObject); 
		}
	}
}
