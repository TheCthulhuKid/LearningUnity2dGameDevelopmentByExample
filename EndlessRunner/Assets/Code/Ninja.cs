using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour
{
	Animator animator;
	public bool jump = false;
	public bool slide = false;


	// Use this for initialization
	void Start()
	{
		animator = (Animator)GetComponent("Animator");
	}

	// Update is called once per frame
	void Update()
	{

	}

	//	Used instead of Update because we are using a rigid body
	void FixedUpdate()
	{
		MoveCharacter();
	}

	void MoveCharacter()
	{
		//	I have simplified the statements to avoid the multiple if/else
		jump = Input.GetKey(KeyCode.W);
		animator.SetBool("jump", jump);

		slide = Input.GetKey(KeyCode.S);
		animator.SetBool("slide", slide);

		animator.SetBool("run", !slide && !jump);
	}
}
