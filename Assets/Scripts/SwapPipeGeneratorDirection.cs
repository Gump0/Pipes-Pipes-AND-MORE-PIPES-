using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPipeGeneratorDirection : MonoBehaviour
{
    public Quaternion currentRotation;

    public void SwitchDirection(){
        Debug.Log("Executed");
        int randomDirection = Random.Range(1,4);

        switch(randomDirection){
            case 1:
            transform.Rotate(Vector3.up, 90); //
            currentRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            break;
            case 2:
            transform.Rotate(Vector3.down, 90);
            currentRotation = transform.rotation * Quaternion.Euler(0, 270, 0);
            break;
            case 3:
            transform.Rotate(Vector3.left, 90);
            currentRotation = transform.rotation * Quaternion.Euler(-90, 0, 0);
            break;
            case 4:
            transform.Rotate(Vector3.right, 90); //
            currentRotation = transform.rotation * Quaternion.Euler(90, 0, 0);
            break;
        }
    }
}
