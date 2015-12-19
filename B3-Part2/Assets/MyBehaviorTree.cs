using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;
using UnityEngine.UI;

public class MyBehaviorTree : MonoBehaviour
{
	public GameObject Hero;
	public GameObject Demon;
	public Transform heroPos;
	public Transform demonPos;
	public Text story;

	private BehaviorAgent behaviorAgent;
	private Animator demonAnim,heroAnim;


	void Start ()
	{
		demonAnim = Demon.GetComponent<Animator> ();
		heroAnim = Demon.GetComponent<Animator> ();

		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}

	void Update ()
	{
		int killCheck = UnityEngine.Random.Range (0, 10);
		
		if (killCheck >= 0 && killCheck <= 6)
		{
			if((Mathf.Abs(heroPos.transform.position.x - demonPos.transform.position.x) <= 3f && Mathf.Abs(heroPos.transform.position.z - demonPos.transform.position.z) <= 3f))
			{
				if(Input.GetKey(KeyCode.F))
				{
					story.text = "Die Demon!!";
					demonAnim.SetBool("toDie",true);
					story.text = "Thank you for killing the Demon! You have saved the kingdom!";
				}
			}
		}
		else
		{
			demonAnim.SetBool("toDie",false);
		}	
	}
	
	protected Node ST_ApproachAndWait(Transform target)
	{
		Val<Vector3> position = Val.V (() => target.position);
		return new Sequence( Hero.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node BuildTreeRoot()
	{
		Node goToDemon = new DecoratorLoop(new Sequence(this.ST_ApproachAndWait(this.Demon.transform)));
		Node killDemon = new DecoratorLoop(new Sequence(this.ST_ApproachAndWait(this.Demon.transform)));
		Node root = new DecoratorLoop (new DecoratorForceStatus (RunStatus.Success, new Sequence(goToDemon,killDemon)));

		return root;
	}
}