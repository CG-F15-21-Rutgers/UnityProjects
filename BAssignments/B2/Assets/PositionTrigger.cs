using UnityEngine;
using System.Collections;

public class PositionTrigger : MonoBehaviour {
    public Transform door1;
	public Transform door2;
	public Transform chair;
	public Transform chair2;

    private bool t = false;
    
	public Animator anim;
	public GameObject RichardFight;
	public GameObject HarryFight;
    
	private bool ReachedDoor=false;
	private bool ReachedChair=false;
	private bool ReachedFight=false;
	private bool NowDie = false;
	private bool NowRise = false;
    
	// Use this for initialization
	void Start () 
	{
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {

		if ((Mathf.Abs(this.transform.position.x - door1.transform.position.x) <= 1f && Mathf.Abs(this.transform.position.z - door1.transform.position.z) <= 1f) || (Mathf.Abs(this.transform.position.x - door2.transform.position.x) <= 1f && Mathf.Abs(this.transform.position.z - door2.transform.position.z) <= 1f))
        {
            ReachedDoor = true;
        }
        else
        {
            ReachedDoor = false;
        }


		if ((Mathf.Abs(this.transform.position.x - chair.transform.position.x) <= 1f && Mathf.Abs(this.transform.position.z - chair.transform.position.z) <= 1f) || (Mathf.Abs(this.transform.position.x - chair2.transform.position.x) <= 1f && Mathf.Abs(this.transform.position.z - chair2.transform.position.z) <= 1f))
		{
			//transform.LookAt(chair,(Vector3.zero));
			ReachedChair = true;
		}
		else
		{
			ReachedChair = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift) == true) 
		{
			if ((Mathf.Abs (this.transform.position.x - RichardFight.transform.position.x) <= 1f && Mathf.Abs (this.transform.position.z - RichardFight.transform.position.z) <= 1f) || (Mathf.Abs (this.transform.position.x - HarryFight.transform.position.x) <= 1f && Mathf.Abs (this.transform.position.z - HarryFight.transform.position.z) <= 1f)) 
			{
				ReachedFight = true;
				NowDie = true;
				anim.Play("Dying",0,0f);
			}
		}
		else
		{
			ReachedFight = false;
			NowDie = false;
		}


		int checkRising = Random.Range(0,2);

		if (checkRising == 1 && NowDie == true) 
		{
			NowRise = true;
		}
		else 
		{
			NowRise = false;
		}

        
		anim.SetBool("ReachedDoor", ReachedDoor);
		anim.SetBool("ReachedChair", ReachedChair);
		anim.SetBool("ReachedFight", ReachedFight);
		anim.SetBool ("NowDie",NowDie);
		anim.SetBool ("NowRise",NowRise);
    }
}