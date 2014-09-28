using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	float speed = 2.0f;

	bool right = false;
	bool up = false;
	bool left = false;
	bool down = false;

	Animator animator;

	//	These must be public in order to assign objects via the inspector
	public Rigidbody2D enemy;
	public Rigidbody2D orb;

	float orbSpeed = 20f;
	float orbSpeed2 = -20f;

	// Use this for initialization
	void Start () {
		animator = (Animator)GetComponent("Animator");

		EnemySpawn ();
		//	The book states that the "InvokeRepeating" calls should be made outwith a function. In C# this isn't possible
		InvokeRepeating("EnemySpawn", 3, 3);
	}
	
	// Update is called once per frame
	void Update () {
		//	TODO: I am doing something wrong here the orb fires strangely
		if(Input.GetButtonDown("Fire1"))
		{
			var orbInstance = (Rigidbody2D)Instantiate(orb, transform.position, Quaternion.Euler(new Vector3(-1,0,0)));
			
			if (right)
			{
				orbInstance.velocity = new Vector2(orbSpeed, 0);
			}

			if (left)
			{
				orbInstance.velocity = new Vector2(orbSpeed2, 0);
			}
			
			if (up)
			{
				orbInstance.velocity = new Vector2(0, orbSpeed);
			}

			if (down)	
			{
				orbInstance.velocity = new Vector2(0, orbSpeed2);
			}
			
		}
	}

	void FixedUpdate () {
		MoveCharacter ();
	}
	
	void MoveCharacter(){

		//	TODO: Use xBox controller

		if (Input.GetKey(KeyCode.A)) {
			animator.SetBool("left", true);
			animator.SetBool("up", false);
			animator.SetBool("down", false);
			animator.SetBool("right", false);
			
			left = true;
			up = right = down = false;
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.D)) {
			animator.SetBool("left", false);
			animator.SetBool("up", false);
			animator.SetBool("down", false);
			animator.SetBool("right", true);
			
			right = true;
			up = left = down = false;
			
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.W)) {
			animator.SetBool("left", false);
			animator.SetBool("up", true);
			animator.SetBool("down", false);
			animator.SetBool("right", false);
			
			up = true;
			left = right = down = false;
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.S)) {
			animator.SetBool("left", false);
			animator.SetBool("up", false);
			animator.SetBool("down", true);
			animator.SetBool("right", false);
			
			down = true;
			up = left = right = false;
			
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
	}

	void EnemySpawn()
	{
		//	Why does a variable have to be assigned?
		var enemyInstance = (Rigidbody2D)Instantiate (enemy, new Vector3(Random.Range (2, 8), Random.Range (-4, 4), 0), Quaternion.Euler (new Vector3 (0, 0, 0)));
	}

	void OnGUI()
	{
		//	TODO: Alter formatting
		GUI.Box(new Rect(10,10,100,90), "" + Time.time);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//	TODO: Add death effect
		if((other.gameObject.name=="enemy(Clone)")||(other.gameObject.name=="right")||(other.gameObject.name=="left")||(other.gameObject.name=="bottom")||(other.gameObject.name=="top"))
		{
			Time.timeScale = 0;
			Destroy(gameObject);
		}
	}
}
