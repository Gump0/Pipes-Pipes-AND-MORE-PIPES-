using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class OnChangeDirTrue : ConditionTask {

		private SwapPipeGeneratorDirection swapPipeGeneratorDirection;

		public BBParameter<bool> changeDirCheck;

		protected override string OnInit(){
			swapPipeGeneratorDirection = agent.GetComponent<SwapPipeGeneratorDirection>();
			if(swapPipeGeneratorDirection == null) Debug.LogWarning("MonoBehavior can't be found!");
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if(changeDirCheck.value == true){
				swapPipeGeneratorDirection.SwitchDirection();
				return true;
			} else{
				return false;
			}
		}
	}
}