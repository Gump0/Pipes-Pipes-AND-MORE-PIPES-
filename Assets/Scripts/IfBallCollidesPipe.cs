using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IfBallCollidesPipe : MonoBehaviour
{
    [SerializeField] private Material ballMat;
    public int numberOfBoundryBoxHits;
    
    void Update(){
        if(numberOfBoundryBoxHits >= 15){
            Debug.Log("LoadScene");
            SceneManager.LoadScene("MainScene");
        }
    }
    //Again very lazy :(
    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;
        Debug.Log("Collided with object tagged: " + collidedObjectTag);

        if(collidedObjectTag == "Pipe1" || collidedObjectTag == "Pipe2" || collidedObjectTag == "Pipe3"){
            GameObject[] objectsWithSameName = GameObject.FindGameObjectsWithTag(collidedObjectTag);

            foreach (GameObject obj in objectsWithSameName){
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null){
                    renderer.material = ballMat;
                }
                else{
                    Debug.LogWarning("Object '" + obj.name + "' does not have a Renderer component.");
                }
            }
        } else if( collidedObjectTag == "Barrier"){
            numberOfBoundryBoxHits++;
        }
    }
}
