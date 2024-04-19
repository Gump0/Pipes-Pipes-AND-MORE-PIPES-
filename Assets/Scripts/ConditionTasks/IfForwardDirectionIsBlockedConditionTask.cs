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
			Debug.DrawLine(agent.transform.position, agent.transform.forward * 3, Color.red);
			Ray fowardRay = new Ray(agent.transform.position, agent.transform.forward * 3);
			RaycastHit hit;
			if(Physics.Raycast(fowardRay, out hit, 3)){
				Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
				if(hit.collider.CompareTag("Barrier")){
					Debug.Log("Hit object with tag 'Barrier': " + hit.collider.gameObject.name);
					return true;
				}
			}
			return false;
		}
	}
}