using UnityEngine;
using System.Collections;

public class PeasantAnimations : MonoBehaviour {

	public GameObject Demon;
	public GameObject peasantGirl;
	public GameObject peasantMan;
	public Animator girlAnim;
	public Animator manAnim;
	
	private bool peasantDie = false;

	// Use this for initialization
	void Start () 
	{
		girlAnim = GetComponent<Animator> ();
		manAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Mathf.Abs (peasantGirl.transform.position.x - Demon.transform.position.x) <= 1f && Mathf.Abs (peasantGirl.transform.position.z - Demon.transform.position.z) <= 1f) || (Mathf.Abs (peasantMan.transform.position.x - Demon.transform.position.x) <= 1f && Mathf.Abs (peasantMan.transform.position.z - Demon.transform.position.z) <= 1f))
			peasantDie = true;
		else
			peasantDie = false;

		girlAnim.SetBool ("peasantDie", peasantDie);
		manAnim.SetBool ("peasantDie", peasantDie);
	}
}
