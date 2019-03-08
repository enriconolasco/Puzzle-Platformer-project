using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Mudar o nome da classe

[DisallowMultipleComponent]
public class TeleportAbillity : MonoBehaviour
{   
    // Number of positions that can be recorded (1s = +-60).
    public int numberOfPositionsStored = 240;
    // Colldown Time in seconds.
    public float cooldownTimeSeconds = 4f;
    // Boolean value to allow the use of the abillity.
    bool isAvailable = true;
    // List for recording the game object positions. 
    List<Vector3> positions = new List<Vector3>();
    
    //  Mehtod Name:    StorePosition
    //  Arguments:      -
    //  Return type:    void
    //  Discription:    Each call stores the current position of the gameObject 
    //                  into the 'positions' list. The elements in the list are
    //                  always inserted in the [0] index, so all the elements 
    //                  above are shifted by +1. This means that the oldest 
    //                  position recorded is always the last one on the list 
    //                  (which has an index value of 'numberOfPositionsToBeStored - 1').     
    public  void StorePosition() 
    {
        positions.Insert(0, transform.position);
        if(positions.Count > numberOfPositionsStored) 
        {
            positions.RemoveAt(numberOfPositionsStored); 
        }
    }                        

    //  Mehtod Name:    Teleport
    //  Arguments:      -
    //  Return type:    void
    //  Discription:    Sets the position of the gameObject to the last position
    //                  in the 'positions' list.
    public  void Teleport() 
    {                                                
        if (Time.timeSinceLevelLoad > cooldownTimeSeconds) 
        {
            transform.position = positions[numberOfPositionsStored - 1];
        }
    }

    // MonoBehaviour Method
    public void FixedUpdate()
    {
        StorePosition();
    }

    // MonoBehaviour Method
    public void Update()
    {
        if (Input.GetKey(KeyCode.R) && isAvailable) 
        {
            Teleport();
            StartCoroutine(Cooldown());
        }
    }

    // Cooldown Enumerator
    IEnumerator Cooldown()
    {    
        isAvailable = false;
        yield return new WaitForSecondsRealtime(cooldownTimeSeconds);
        isAvailable = true;
    }
}
