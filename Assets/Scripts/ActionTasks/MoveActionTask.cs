using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class MoveActionTask : ActionTask {

		private SwapPipeGeneratorDirection swapPipeGeneratorDirection;

		public GameObject pipePrefab;
		public float pipeSpacing = 6f, distanceSinceLastPipe = 0f, generatorSpeed = 8f;
		public Material[] pipeMatList;
		private Material currentPipeMaterial;
		private Vector3 prefabSpawnPoint;

		protected override string OnInit() {
			swapPipeGeneratorDirection = agent.GetComponent<SwapPipeGeneratorDirection>();
			currentPipeMaterial = pipeMatList[Random.Range(0, pipeMatList.Length)];
			return null;
		}

		protected override void OnExecute() {
			prefabSpawnPoint = agent.transform.position;
		}

		protected override void OnUpdate() {
			distanceSinceLastPipe = Vector3.Distance(agent.transform.position, prefabSpawnPoint);
			if(distanceSinceLastPipe >= pipeSpacing){
				GameObject newPipe = UnityEngine.Object.Instantiate(pipePrefab, agent.transform.position, swapPipeGeneratorDirection.currentRotation);
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
	}
}