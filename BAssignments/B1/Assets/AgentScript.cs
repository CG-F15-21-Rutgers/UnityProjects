using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {
	//public Transform target;
	NavMeshAgent agent;
	private Vector3 temp1,temp2;
	//public Camera camera;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.enabled = false;

	//RaycastHit hit;
	//Ray ray = camera.ScreenPointToRay(Input.mousePosition);
	
	//if (Physics.Raycast(ray, out hit)) {
		//Transform objectHit = hit.transform;
		//	target = objectHit;
		// Do something with the object that was hit by the raycast.
	

		//agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {


		
		if (Input.GetMouseButtonDown(0)) {
			agent.enabled=false;
			RaycastHit hit;
			
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000000)) {
				temp1 = hit.point;
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			RaycastHit hit;
			
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000000)) {
				temp2 = hit.point;
			}
			if(agent.transform.position.x>temp1.x && agent.transform.position.x < temp2.x &&agent.transform.position.z < temp1.z &&agent.transform.position.z>temp2.z)
			{
				agent.enabled = true;
			}
		}


		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;
			
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000000000000)) {
				agent.destination = hit.point;
	}
}
	
	}
		//agent.SetDestination (target.position);}
}
