using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class MoveActionTask : ActionTask {
		public GameObject pipePrefab;
		public float pipeSpacing = 6f, distanceSinceLastPipe = 0f, generatorSpeed = 8f;
		public Material[] pipeMatList;
		private Material currentPipeMaterial;
		private Vector3 prefabSpawnPoint;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			prefabSpawnPoint = agent.transform.position;
			currentPipeMaterial = pipeMatList[Random.Range(0, pipeMatList.Length)];
		}

		protected override void OnUpdate() {
			distanceSinceLastPipe = Vector3.Distance(agent.transform.position, prefabSpawnPoint);
			if(distanceSinceLastPipe >= pipeSpacing){
				GameObject newPipe = UnityEngine.Object.Instantiate(pipePrefab, agent.transform.position, Quaternion.Euler(90, 0, 0));
				ApplyMaterialToPipe(newPipe, currentPipeMaterial);
				pipeSpacing = 0f;
			}
			agent.transform.Translate(Vector3.forward * generatorSpeed * Time.deltaTime);
		}

		private void ApplyMaterialToPipe(GameObject pipe, Material material) {
            Renderer pipeRenderer = pipe.GetComponent<Renderer>();
            if (pipeRenderer != null) {
                pipeRenderer.material = material;
            }
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}