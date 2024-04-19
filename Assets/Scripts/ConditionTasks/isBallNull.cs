using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class isBallNull : ConditionTask {
		private GameObject childBallObject;
		protected override string OnInit(){
			childBallObject = GameObject.Find("Ball");
			return null;
		}
		protected override void OnEnable() {
			
		}
		protected override void OnDisable() {
			
		}
		protected override bool OnCheck() {
			if(childBallObject == null){
				return false;
			} else{
				return true;
			}
		}
	}
}