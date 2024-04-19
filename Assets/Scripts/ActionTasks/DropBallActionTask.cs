using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DropBallActionTask : ActionTask {

		public GameObject childBallObject;
		private Rigidbody childRB;
		protected override string OnInit() {
			childBallObject = GameObject.Find("Ball");
			childRB = childBallObject.GetComponent<Rigidbody>();
			return null;
		}
		protected override void OnExecute() {
			childRB.useGravity = childRB.useGravity = true;
			childBallObject.transform.parent = null;
			EndAction(true);
		}
	}
}