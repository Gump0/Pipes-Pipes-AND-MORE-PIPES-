using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PlayerControlBallDropActionTask : ActionTask {

		private float elapsedTime;

		protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
			elapsedTime = 0f;
		}
		protected override void OnUpdate() {
			elapsedTime += Time.deltaTime;
			if(Input.GetKeyDown(KeyCode.Space) || elapsedTime >= 10){ // If 10 seconds pass or space is pressed, drop the ball
				EndAction(true);
			}
		}
		protected override void OnStop() {
			
		}
		protected override void OnPause() {
			
		}
	}
}