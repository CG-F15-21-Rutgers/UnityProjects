using UnityEngine;
using System.Collections;

public class HarryInteraction : MonoBehaviour {

	private Animator anim;
	private bool windMill;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		windMill = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) {
			windMill = true;
			anim.SetBool ("windMill", windMill);
		} 
		else 
		{
			windMill = false;
			anim.SetBool("WindMill",windMill);
		}
		//if(windMill)
		//	anim.Play ("WindmillLoop");
	}
}
