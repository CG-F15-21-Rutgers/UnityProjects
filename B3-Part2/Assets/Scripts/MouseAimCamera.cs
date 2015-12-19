using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour {
	public GameObject target;
	public float rotateSpeed = 2;
	Vector3 offset;
	Vector3 offsetPush = new Vector3(0.0f,2.0f,0.0f);

	void Start() 
	{
		offset = target.transform.position - transform.position + offsetPush;
	}
	
	void LateUpdate() {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);
		
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}
}