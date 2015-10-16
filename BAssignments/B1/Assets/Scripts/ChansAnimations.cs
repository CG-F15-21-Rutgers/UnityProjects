using UnityEngine;
using System.Collections;

public class ChansAnimations : MonoBehaviour {

	public Animator anim;

	private Rigidbody rb;
	private float inputH;
	private float inputV;
	private bool run;
	private bool jump;
	private bool slide;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		run = false;
		slide = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			int damageN = Random.Range(0,2);

			if(damageN == 0)
			{
				anim.Play("DAMAGED00",-1,0f);
			}
			else
			{
				anim.Play("DAMAGED01",-1,0f);
			}
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

		if (Input.GetKey (KeyCode.LeftControl)) 
		{
			anim.SetBool("slide", true);
		} 
		else 
		{
			anim.SetBool("slide",false);
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

		if (slide) 
		{
			anim.Play("SLIDE00",-1,0f);
		}
		
		rb.velocity = new Vector3(moveX,0f,moveZ);
		Vector3 movement = new Vector3 (inputH, 0.0f, inputV);
		
		rb.AddForce (movement);
	}
}