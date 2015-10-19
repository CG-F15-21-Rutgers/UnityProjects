using UnityEngine;
using System.Collections;

public class ChansAnimations : MonoBehaviour {

	public Animator anim;
	
	NavMeshAgent agent;
	private Vector3 temp1,temp2;

	private Rigidbody rb;
	private float inputH;
	private float inputV;
	private bool run;
	private bool jump;
	private bool slide;
	private bool moveWalk;
	private bool moveRun;
	private bool oneClick = false;
	private bool timer_running;
	private float timer_for_doubleClick;
	private float delay;

	void Start () 
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		run = false;
		slide = false;
		agent = GetComponent<NavMeshAgent>();
		agent.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetMouseButtonDown (0)) 
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
		}	*/
		
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

		
		if (Input.GetMouseButtonDown(0)) 
		{
			agent.enabled=false;
			RaycastHit hit;
			
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000000)) 
			{
				temp1 = hit.point;
			}
		}
		
		if (Input.GetMouseButtonUp(0)) 
		{
			RaycastHit hit;
			
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000000)) 
			{
				temp2 = hit.point;
			}
			if(agent.transform.position.x>temp1.x && agent.transform.position.x < temp2.x &&agent.transform.position.z < temp1.z &&agent.transform.position.z>temp2.z)
			{
				agent.enabled = true;
			}
		}
		
		if (Input.GetMouseButtonDown(1)) 
		{
			if(!oneClick)
			{
				oneClick = true;

				timer_for_doubleClick = Time.time;

				RaycastHit hit;
				
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000000000000))
				{
					agent.destination = hit.point;
					moveWalk = true;
					anim.SetBool("moveWalk",true);
					anim.SetBool("moveRun",false);
				}
				
				if (Mathf.Abs(this.transform.position.x - hit.point.x) <= 25f && Mathf.Abs(this.transform.position.z - hit.point.z) <= 25f)
				{
					anim.SetBool("moveWalk",false);
					anim.SetBool("moveRun",false);
				}
			}
			else
			{
				oneClick = false;

				RaycastHit hit;
				
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000000000000))
				{
					agent.destination = hit.point;
					moveWalk = false;
					moveRun = true;
					anim.SetBool("moveWalk",false);
					anim.SetBool("moveRun",true);
				}
				
				if (Mathf.Abs(this.transform.position.x - hit.point.x) <= 25f && Mathf.Abs(this.transform.position.z - hit.point.z) <= 25f)
				{
					anim.SetBool("moveWalk",false);
					anim.SetBool("moveRun",false);
				}
			}
		}

		if (oneClick) 
		{
			if(Time.time - timer_for_doubleClick > delay)
			{
				oneClick = false;
			}
		}
	}
}