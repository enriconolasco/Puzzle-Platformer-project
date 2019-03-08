using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesAndDeathZone : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterController>().Die();
        }
    }
}
