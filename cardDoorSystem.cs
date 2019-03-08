using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardDoorSystem : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openDoor;
    Vector3 doorPosition;

    void Start()
    {
        doorPosition = closedDoor.transform.position;
    }
   
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<CharacterController>().isCarryingCard == true && !col.isTrigger)
        {
            Destroy(closedDoor.gameObject);
            Instantiate(openDoor, doorPosition, Quaternion.identity);
        }
    }
}
