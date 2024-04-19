using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CheckForwardDirection : ActionTask {

		public BBParameter<bool> changeDirCheck;
		private bool randomRollProc = false;

		protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
			changeDirCheck.value = false;
		}
		protected override void OnUpdate() {
			Debug.DrawLine(agent.transform.position, agent.transform.forward * 3, Color.red);
			Ray fowardRay = new Ray(agent.transform.position, agent.transform.forward * 3);
			RaycastHit hit;
			if(Physics.Raycast(fowardRay, out hit, 3)){
				Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
				if(hit.collider.CompareTag("Barrier") || randomRollProc){
					Debug.Log("Hit object with tag 'Barrier': " + hit.collider.gameObject.name);
					randomRollProc = false;
					EndAction(true);
				}
				if(hit.collider.CompareTag("Pipe")){
					UnityEngine.Object.Destroy(agent.gameObject);
				}
			}
			RollRandomTurnChance();
		}
		protected override void OnStop() {
			changeDirCheck.value = true;
		}
		void RollRandomTurnChance(){
			int randInt = Random.Range(0,999);
			if(randInt >= 777){
				randomRollProc = true;
			}
		}
	}
}