using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CollectableObject : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<CharacterController>().isCarryingCard = true;
        }
    }
}
