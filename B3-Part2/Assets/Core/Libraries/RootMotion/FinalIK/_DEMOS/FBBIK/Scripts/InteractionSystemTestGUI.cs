using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using UnityEngine.UI;

namespace RootMotion.FinalIK.Demos {


	/// <summary>
	/// Simple GUI for quickly testing out interactions.
	/// </summary>
	[RequireComponent(typeof(InteractionSystem))]
	public class InteractionSystemTestGUI : MonoBehaviour {
		public Text story;
		[SerializeField] InteractionObject interactionObject; // The object to interact to
		[SerializeField] FullBodyBipedEffector[] effectors; // The effectors to interact with

		private InteractionSystem interactionSystem;
		
		void Awake() {
			interactionSystem = GetComponent<InteractionSystem>();
		}

		void OnGUI() {
			if (interactionSystem == null) return;

			if (GUILayout.Button("Pickup Axe") && (Mathf.Abs(this.transform.position.x - interactionObject.transform.position.x) <= 3f && Mathf.Abs(this.transform.position.z - interactionObject.transform.position.z) <= 3f)) 
			{	
				story.text = "The axe has been picked up, YeeHaw! Go near the demon and press F twice to attack!";
				if (effectors.Length == 0) Debug.Log("Please select the effectors to interact with.");

				foreach (FullBodyBipedEffector e in effectors) {
					interactionSystem.StartInteraction(e, interactionObject, true);
				}
			}

			if (effectors.Length == 0) return;

			if (interactionSystem.IsPaused(effectors[0])) {
				if (GUILayout.Button("Resume Interaction With " + interactionObject.name)) {

					interactionSystem.ResumeAll();
				}
			}
		}
	}
}
