using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NodeCanvas.Tasks.Actions {

	public class ResetScene : ActionTask {

		private IfBallCollidesPipe ifBallCollidesPipe;

		protected override string OnInit() {
			ifBallCollidesPipe = agent.GetComponent<IfBallCollidesPipe>();
			return null;
		}
		protected override void OnExecute() {
		}
		protected override void OnUpdate() {
			if(ifBallCollidesPipe != null){
				if(ifBallCollidesPipe.numberOfBoundryBoxHits >= 15){
					Debug.Log("LoadScene");
					SceneManager.LoadScene("MainScene");
				}
			}
		}
	}
}