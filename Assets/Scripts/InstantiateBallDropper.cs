using UnityEngine;

public class CheckPipeGenerators : MonoBehaviour
{
    [SerializeField] private GameObject ballDropperPrefab;
    private GameObject[] pipeGenerators;
    void Update()
    {
        pipeGenerators = GameObject.FindGameObjectsWithTag("Pipe-Generator");
        GameObject isThereaballDropper = GameObject.FindGameObjectWithTag("BallDropper");

        if (pipeGenerators.Length > 0){
            foreach (GameObject pipeGenerator in pipeGenerators){
                Debug.Log("Pipe-Generator found: " + pipeGenerator.name);
            }
        }else{
            if(ballDropperPrefab != null && isThereaballDropper == null){
                Instantiate(ballDropperPrefab, new Vector3(0,12,0), Quaternion.identity);
            } else{
                //Debug.LogWarning("ballDropperPrefab was not found");
            }
        }
    }
}
