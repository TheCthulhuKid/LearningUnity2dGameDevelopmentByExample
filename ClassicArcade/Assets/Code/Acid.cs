using UnityEngine;
using System.Collections;

public class Acid : MonoBehaviour
{
	public Rigidbody2D acid;

	float speed = -3.0f;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SpawnAcid", 3, 7);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SpawnAcid()
	{
		var acidInstance = (Rigidbody2D)Instantiate(acid, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
		
		acidInstance.name = "Acid(Clone)";
		acidInstance.velocity = new Vector2(0, speed);
	}
}
