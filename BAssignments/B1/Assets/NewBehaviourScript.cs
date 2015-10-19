using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    NavMeshObstacle obs;
    Vector3 temp2;
    int a;
    // Use this for initialization
    void Start()
    {
        obs = GetComponent<NavMeshObstacle>();
        obs.enabled = true;
        a = 0;
    }


    void FixedUpdate()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        //float Vertical = Input.GetAxis ("Vertical");


        Vector3 movement = new Vector3(Horizontal, 0.0f, 0.0f);

        if (a == 1)
        {
			if(obs.transform.position.x + movement.x > 93.5 && obs.transform.position.x + movement.x < 101)
                obs.transform.position += movement;

        }

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000000))
            {
                temp2 = hit.point;
            }
            if (Mathf.Abs(obs.transform.position.x - temp2.x) <= 10 && Mathf.Abs(obs.transform.position.y - temp2.y) <= 10)
            {
                a = 1;
            }
            else
                a = 0;
        }
    }
}
