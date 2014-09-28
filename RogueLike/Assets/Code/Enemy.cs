using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject heroObj;
	float enemySpeed;

	//	These values are present in the books example code but I see no use for them
//	bool enemyRight = false;
//	bool enemyUp = false;
//	bool enemyLeft = false;
//	bool enemyDown = false;
	
	Animator enemyAnimator;

	// Use this for initialization
	void Start () {
		enemySpeed = 1.0f;

		//	The book states that the "InvokeRepeating" calls should be made outwith a function. In C# this isn't possible
		InvokeRepeating("Accelerate", 2, 5);
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMove ();
	}

	void EnemyMove(){
		heroObj = GameObject.Find ("hero");
		enemyAnimator = (Animator)GetComponent ("Animator");

		if (heroObj != null)
		{
			if (transform.position.y > heroObj.transform.position.y)
			{
				
				enemyAnimator.SetBool("enemyLeft", false);
				enemyAnimator.SetBool("enemyUp", false);
				enemyAnimator.SetBool("enemyDown", true);
				enemyAnimator.SetBool("enemyRight", false);
//				enemyDown = true;
//				enemyLeft = false;
//				enemyRight = false;
//				enemyUp = false;
				transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
				
			}
			else
			{
				enemyAnimator.SetBool("enemyLeft", false);
				enemyAnimator.SetBool("enemyUp", true );
				enemyAnimator.SetBool("enemyDown", false );
				enemyAnimator.SetBool("enemyRight", false );
//				enemyDown = false;
//				enemyLeft = false;
//				enemyRight = false;
//				enemyUp = true;
				transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
			}
			
			if (transform.position.x < heroObj.transform.position.x)
			{
				
				enemyAnimator.SetBool("enemyLeft", false);
				enemyAnimator.SetBool("enemyUp", false );
				enemyAnimator.SetBool("enemyDown", false );
				enemyAnimator.SetBool("enemyRight", true );
//				enemyDown = false;
//				enemyLeft = false;
//				enemyRight = true;
//				enemyUp = false;
				transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
			}
			else
			{
				enemyAnimator.SetBool("enemyLeft", true);
				enemyAnimator.SetBool("enemyUp", false );
				enemyAnimator.SetBool("enemyDown", false );
				enemyAnimator.SetBool("enemyRight", false );
//				enemyDown = false;
//				enemyLeft = true;
//				enemyRight = false;
//				enemyUp = false;
				transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
			}
		}
	}
	
	void Accelerate()
	{
		enemySpeed = enemySpeed + 1;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name=="orb(Clone)")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
