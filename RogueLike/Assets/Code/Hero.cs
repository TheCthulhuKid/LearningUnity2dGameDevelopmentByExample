using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	float speed = 2.0f;

	bool right = false;
	bool up = false;
	bool left = false;
	bool down = false;

	Animator animator;

	public Rigidbody2D enemy;

	// Use this for initialization
	void Start () {
		animator = (Animator)GetComponent("Animator");

		EnemySpawn ();
		InvokeRepeating("EnemySpawn", 3, 3);
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveCharacter ();
	}

	void FixedUpdate () {
		MoveCharacter ();
	}
	
	void MoveCharacter(){

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
		var enemyInstance = (Rigidbody2D)Instantiate (enemy, new Vector3(Random.Range (2, 8), Random.Range (-4, 4), 0), Quaternion.Euler (new Vector3 (0, 0, 0)));
	}
}
