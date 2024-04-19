using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PlayerControlBallDropActionTask : ActionTask {

		private float elapsedTime, xFactor, zFactor;

		protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
			elapsedTime = 0f;
			xFactor = 0f;
			zFactor = 0f;
		}
		protected override void OnUpdate() {
			//Very lazy key input system lol
			if(Input.GetKeyDown(KeyCode.W) && zFactor < 26){
				zFactor ++;
			}
			if(Input.GetKeyDown(KeyCode.A) && xFactor < 16.5){
				xFactor ++;
			}
			if(Input.GetKeyDown(KeyCode.S) && zFactor > -1){
				zFactor --;
			}
			if(Input.GetKeyDown(KeyCode.D) && xFactor > -17){
				xFactor --;
			}

			agent.transform.position = new Vector3(xFactor, agent.transform.position.y, zFactor);

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