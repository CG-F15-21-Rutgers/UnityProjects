using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class MyBehaviorTree : MonoBehaviour
{

    public Animator Daniel;
    public GameObject participant;
	public GameObject Richard;
	public GameObject Harry;
	public GameObject FightRichard;
	public GameObject FightHarry;

    public Transform door1;
    public Transform seat1;
	public Transform seat2;

	private int CardArcCheck = 0;
	//private int FightArcCheck = 0;

	private bool ReachedDoor;
    private BehaviorAgent behaviorAgent;

    void Start()
    {
		/*behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
		BehaviorManager.Instance.Register(behaviorAgent);
		behaviorAgent.StartBehavior();
		*/
	}

	protected Node CardsArc()
	{
		if (CardArcCheck == 0)
		{
			return new Sequence (this.ST_ApproachAndWait (this.seat1,participant),participant.GetComponent<BehaviorMecanim>().Node_OrientTowards(Richard.transform.position));
		} 
		else
		{
			return new Sequence (this.ST_ApproachAndWait (this.seat2,participant),participant.GetComponent<BehaviorMecanim>().Node_OrientTowards(Harry.transform.position));
		}
	}
	
	protected Node FightArc()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift) == true) 
		{
			if (CardArcCheck == 1)
			{
				return new Sequence ((this.ST_ApproachAndWait (FightHarry.transform,participant)),(this.ST_ApproachAndWait (FightHarry.transform,Harry)));
			}
			else
			{
				return new Sequence ((this.ST_ApproachAndWait (FightRichard.transform,participant)),(this.ST_ApproachAndWait (FightRichard.transform,Richard)));
			}
		}
		else
			return new Sequence (CardsArc ());
	}
    
	// Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.Mouse0) == true) 
		{
			behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
			BehaviorManager.Instance.Register (behaviorAgent);
			behaviorAgent.StartBehavior ();
		} 
		else if (Input.GetKeyDown (KeyCode.Mouse1) == true) 
		{
			CardArcCheck = 1;
			behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
			BehaviorManager.Instance.Register (behaviorAgent);
			behaviorAgent.StartBehavior ();
		}

		if (Input.GetKeyDown (KeyCode.LeftShift) == true) 
		{
			behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
			BehaviorManager.Instance.Register (behaviorAgent);
			behaviorAgent.StartBehavior ();
		}
	}
	
    protected Node ST_ApproachAndWait(Transform target, GameObject wanderer)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(wanderer.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }
	
    protected Node BuildTreeRoot()
    {
		return
			new Sequence (CardsArc(),FightArc());
    }
}