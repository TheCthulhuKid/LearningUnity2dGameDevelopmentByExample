using UnityEngine;
using System.Collections;

public class Grime : MonoBehaviour
{
	public Rigidbody2D grime;

	float speed = -3.0f;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SpawnGrime", 2, 7);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SpawnGrime()
	{
		var grimeInstance = (Rigidbody2D)Instantiate(grime, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

		grimeInstance.name = "Grime(Clone)";
		grimeInstance.velocity = new Vector2(0, speed);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name.Equals("Spongy"))
		{
			Destroy(gameObject);
		}
	}
}
