using UnityEngine;
using System.Collections;

public class CharacterActions : MonoBehaviour {

	public Animator anim;

	private float inputH;
	private float inputV;
	private bool run;
	private bool jump;
	private Rigidbody rb;
	
	void Start () 
	{
		anim.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody>();
		run = false;
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.F)) 
		{
			anim.SetBool ("attack", true);
			anim.SetBool ("didHeAttack", true);
		} 
		else 
		{
			anim.SetBool("attack", false);
		}

		if(Input.GetKey(KeyCode.LeftShift))
		{
			run = true;
		}
		else
		{
			run = false;
		}
		
		if (Input.GetKey (KeyCode.Space)) 
		{
			anim.SetBool("jump", true);
		} 
		else 
		{
			anim.SetBool("jump",false);
		}

		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");
		
		anim.SetFloat("inputH",inputH);
		anim.SetFloat("inputV",inputV);
		anim.SetBool("run",run);

		float moveX = inputH*20f*Time.deltaTime;
		float moveZ = inputV*50f*Time.deltaTime;
		
		if(moveZ <= 0f)
		{
			moveX = 0f;
		}
		else if(run)
		{
			moveX*=3f;
			moveZ*=3f;
		}

		rb.velocity = new Vector3(moveX,0f,moveZ);
		Vector3 movement = new Vector3 (inputH, 0.0f, inputV);
		
		rb.AddForce (movement);
	}
}