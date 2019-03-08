using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    bool playerTouchedOnce = false;

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!playerTouchedOnce)
            {
                StartCoroutine(waitJumpTime());
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator waitJumpTime()
    {
        yield return new WaitForSeconds(0.05f);
        playerTouchedOnce = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 1.0f;
    }
}
