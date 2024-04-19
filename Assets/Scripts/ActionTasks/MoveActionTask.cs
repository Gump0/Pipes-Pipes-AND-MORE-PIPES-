using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class MoveActionTask : ActionTask {

		private SwapPipeGeneratorDirection swapPipeGeneratorDirection;

		public GameObject[] pipePrefabs;
		private GameObject currentPipe;	
		public float pipeSpacing = 6f, distanceSinceLastPipe = 0f, generatorSpeed = 8f;
		private Vector3 prefabSpawnPoint;

		protected override string OnInit() {
			swapPipeGeneratorDirection = agent.GetComponent<SwapPipeGeneratorDirection>();
			currentPipe = pipePrefabs[Random.Range(0, pipePrefabs.Length)];
			return null;
		}

		protected override void OnExecute() {
			prefabSpawnPoint = agent.transform.position;
		}

		protected override void OnUpdate() {
			distanceSinceLastPipe = Vector3.Distance(agent.transform.position, prefabSpawnPoint);
			if(distanceSinceLastPipe >= pipeSpacing){
				GameObject newPipe = UnityEngine.Object.Instantiate(currentPipe, agent.transform.position, swapPipeGeneratorDirection.currentRotation);
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