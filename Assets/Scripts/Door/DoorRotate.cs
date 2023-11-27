using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{

    public GameObject door;
    private Vector3 targetPosition;
    public float movePosition; 
    public float smoothness; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //set targetPostion
            targetPosition= door.transform.position + new Vector3(0f,0f,movePosition);

            StartCoroutine(MoveSmoothly());
        }
    }
    
    private IEnumerator MoveSmoothly()
    {
        while(Vector3.Distance(door.transform.position,targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.Lerp(door.transform.position,targetPosition,smoothness*Time.deltaTime);
            yield return null;
        }
    }
}
