using UnityEngine;
using System.Collections;

public class HarryPositionTrigger : MonoBehaviour {
	public Transform door;
	public Transform chair;
	private bool t = false;
	
	public Animator anim;
	
	private bool ReachedDoor=false;
	private bool ReachedChair=false;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Mathf.Abs(this.transform.position.x - door.transform.position.x) <= 1f && Mathf.Abs(this.transform.position.z - door.transform.position.z) <= 1f)
		{
			ReachedDoor = true;
		}
		else
		{
			ReachedDoor = false;
		}
		
		if (Mathf.Abs(this.transform.position.x - chair.transform.position.x) <= 1f && Mathf.Abs(this.transform.position.z - chair.transform.position.z) <= 1f)
		{
			//transform.LookAt(chair,(Vector3.zero));
			ReachedChair = true;
		}
		else
		{
			ReachedChair = false;
		}
		
		anim.SetBool("ReachedDoor", ReachedDoor);
		anim.SetBool("ReachedChair", ReachedChair);
	}
}