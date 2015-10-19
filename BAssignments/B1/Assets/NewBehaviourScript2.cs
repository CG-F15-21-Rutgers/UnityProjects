using UnityEngine;
using System.Collections;

public class NewBehaviourScript2 : MonoBehaviour
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

        //float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis ("Vertical");


        Vector3 movement = new Vector3(0.0f, 0.0f, Vertical);

        if (a == 1)
        {
            if (obs.transform.position.z + movement.z > 137.2 && obs.transform.position.z + movement.z < 151.6)
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
