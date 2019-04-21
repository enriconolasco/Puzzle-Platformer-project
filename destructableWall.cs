using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructableWall : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("missile"))
        {
            Destroy(this.gameObject);
        }
    }
}
