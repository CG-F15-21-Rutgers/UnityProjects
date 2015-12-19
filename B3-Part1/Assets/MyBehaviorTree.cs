using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;
using UnityEngine.UI;
public class MyBehaviorTree : MonoBehaviour
{
    public Text display;
    public Transform c1;
    public Transform c2;
    public Transform c3;
    public Transform c4;
    public GameObject civilian1;
	public GameObject civilian2;
	public GameObject civilian3;
    public GameObject civilian4;
    public GameObject participant;
    public GameObject child1;
    private BehaviorAgent behaviorAgent;
    private Animator anim;
    private Animator anim2;
    private Animator anim3;
    private Animator anim4;

    // Use this for initialization

    void Start ()
	{
        anim = civilian1.GetComponent<Animator>();
        anim2 = civilian2.GetComponent<Animator>();
        anim3 = civilian3.GetComponent<Animator>();
        anim4 = civilian4.GetComponent<Animator>();
        behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected Node ST_ApproachAndWait(Transform target1, Transform target2)
	{
        //dani.SetBool("H_Clap",true);
		Val<Vector3> position1 = Val.V (() => target1.position);
        Val<Vector3> position2 = Val.V(() => target2.position);
        //Val<Vector3> position2 = Val.V(() => target2.position);
        //Val<Vector3> position3 = Val.V(() => target3.position);
        //Val<Vector3> position4 = Val.V(() => target4.position);
        Val<String> act = "Cry";
        //Val<String> act3 = "Cheer";
        //Val<String> act4 = "BeingCocky";
        //Val<String> act5 = "Clap";
        //Val<String> act6 = "Bash";
        //Val<String> act7 = "PistolAim";
        //Node walk1 = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position1));
        //Node walk2 = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position2));
        //Node walk3 = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position3));
        //Node walk4 = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position4));
        //Node action = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(act, true), new LeafWait(6000), participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(act, false));
        

        return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position1), participant.GetComponent<BehaviorMecanim>().Node_GoTo(position2));
     
     
	}
    void civfdie()
    {
        anim.SetBool("Die", true);
        display.text = "The Peasant is Dead! Who's next?";
    }

    protected Node killciv1()
    {
        Val<String> attack = "Pointing";
        Val<String> scare = "Dying";
        Action civ1die = () => civfdie();
        Node killaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack,true), new LeafWait(4000));
        Node dekillaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, false));
        Node leaf = new Sequence(new LeafInvoke(civ1die),killaction,dekillaction);
        return leaf;
    }
    void civfdie2()
    {
        anim2.SetBool("Die", true);
        display.text = "Grandma didn't see that coming!";
    }
    protected Node killciv2()
    {
        Val<String> attack = "Pointing";
        Val<String> scare = "Dying";
        Action civ1die = () => civfdie2();
        Node killaction = new Sequence(civilian2.GetComponent<BehaviorMecanim>().Node_OrientTowards(participant.transform.position), participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, true), new LeafWait(4000));
        Node dekillaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, false));
        Node leaf = new Sequence(new LeafInvoke(civ1die), killaction, dekillaction);
        return leaf;
    }
    void civfdie3()
    {
        anim3.SetBool("Die", true);
        display.text = "Poor Girl! Demon is extremely Furious!";
    }
    protected Node killciv3()
    {
        Val<String> attack = "PistolAim";
        Action civ3die = () => civfdie3();
        Node killaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, true), new LeafWait(2000));
        Node dekillaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, false));
        Node leaf = new Sequence(new LeafInvoke(civ3die), killaction, dekillaction);
        return leaf;
    }
    void civfdie4()
    {
        anim4.SetBool("Die", true);
        display.text = "Someone stop the Demon! Please select a Hero to stop the massacre.";
    }

    protected Node killciv4()
    {
        Val<String> attack = "Pointing";
        Val<String> scare = "Dying";
        Action civ1die = () => civfdie4();
        Node killaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, true), new LeafWait(2000));
        Node dekillaction = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(attack, false));
        Node leaf = new Sequence(new LeafInvoke(civ1die), killaction, dekillaction);
        return leaf;
    }
    protected Node BuildTreeRoot()
	{
        Val<Vector3> position1 = Val.V(() => c1.position);
        Val<Vector3> position2 = Val.V(() => c2.position);
        Val<Vector3> position3 = Val.V(() => c3.position);
        Val<Vector3> position4 = Val.V(() => c4.position);
        display.text = "Demon is FURIOUS! He's going on a killing spree!";
        //Val<float> pp = Val.V (() => police.transform.position.z);
        Node DevilKillSpree =  new Sequence(
                        participant.GetComponent<BehaviorMecanim>().Node_GoTo(position1),killciv1(), 
                        participant.GetComponent<BehaviorMecanim>().Node_GoTo(position2),killciv2(), 
                        participant.GetComponent<BehaviorMecanim>().Node_GoTo(position3),killciv3(), 
                        participant.GetComponent<BehaviorMecanim>().Node_GoTo(position4),killciv4(),killciv4()

                        );
        

		Node root =  new Sequence( DevilKillSpree );
		return root;
	}
}
