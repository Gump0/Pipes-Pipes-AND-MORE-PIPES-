using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CheckForwardDirection : ActionTask {

		public BBParameter<bool> changeDirCheck;

		protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
			changeDirCheck.value = false;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Debug.DrawLine(agent.transform.position, agent.transform.forward * 3, Color.red);
			Ray fowardRay = new Ray(agent.transform.position, agent.transform.forward * 3);
			RaycastHit hit;
			if(Physics.Raycast(fowardRay, out hit, 3)){
				Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
				if(hit.collider.CompareTag("Barrier")){
					Debug.Log("Hit object with tag 'Barrier': " + hit.collider.gameObject.name);
					EndAction(true);
				}
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			changeDirCheck.value = true;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}