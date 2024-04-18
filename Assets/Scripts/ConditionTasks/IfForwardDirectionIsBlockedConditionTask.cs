using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IfForwardDirectionIsBlockedConditionTask : ConditionTask {

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			Ray fowardRay = new Ray(agent.transform.position, agent.transform.forward * 3);
			Debug.DrawLine(agent.transform.position, agent.transform.forward * 3, Color.red);
			return false;
		}
	}
}