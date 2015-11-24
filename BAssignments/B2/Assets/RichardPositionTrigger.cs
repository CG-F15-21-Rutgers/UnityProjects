using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class RichardPositionTrigger : MonoBehaviour {
	public Transform door;
	public Transform chair;
	public GameObject Daniel;
	public GameObject RichardFight;

	private bool t = false;
	
	public Animator anim;
	
	private bool ReachedDoor=false;
	private bool ReachedChair=false;
	private bool ReachedFight=false;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	/*protected Node ST_ApproachAndWait(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(this.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}*/

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

		if (Mathf.Abs (this.transform.position.x - Daniel.transform.position.x) <= 1f && Mathf.Abs (this.transform.position.z - Daniel.transform.position.z) <= 1f)
		{
			ReachedFight = true;
		}

		/*if (Mathf.Abs (RichardFight.transform.position.x - Daniel.transform.position.x) <= 1f && Mathf.Abs (RichardFight.transform.position.z - Daniel.transform.position.z) <= 1f) 
		{
			ST_ApproachAndWait(RichardFight.tra);
		}*/

		anim.SetBool("ReachedDoor", ReachedDoor);
		anim.SetBool("ReachedChair", ReachedChair);
		anim.SetBool("ReachedFight", ReachedFight);
	}
}