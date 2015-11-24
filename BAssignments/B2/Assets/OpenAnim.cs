using UnityEngine;
using System.Collections;

public class OpenAnim : MonoBehaviour {
	public Animator daniel;
	public GameObject DanielPosition;

	Vector3 axis;
	Vector3 temp;
	// Use this for initialization
	void Start () {
		temp = transform.position;
		axis = transform.position;
		axis.x -= 1f;
		axis.z -= 0.4f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (daniel.GetBool ("ReachedDoor") == true) 
		{
			if (Mathf.Abs (this.transform.position.x - DanielPosition.transform.position.x) <= 1f && Mathf.Abs (this.transform.position.z - DanielPosition.transform.position.z) <= 1f)
			{
				this.transform.RotateAround (axis, transform.up, Time.deltaTime * 90f);
			}
		}
		else if(daniel.GetBool("ReachedDoor") == false && (temp.z-transform.position.z)>0.01f )
		{
			this.transform.RotateAround(axis, transform.up, Time.deltaTime * -90f);
		}
	}
}