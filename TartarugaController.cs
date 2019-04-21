using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartarugaController : CharacterController
{
    bool isSitting = false;
    public BoxCollider2D back;

    public override void Start()
    {
        moveSpeed = 40.0f;
        jumpHeight = 30.0f;
        characterMass = 170.0f;
        characterStrength = 2;
        thisCharacterIndexNumber = 3;       
        base.Start();
    }

    public override void Update()
    {
        if (gm.selectedCharacterIndex == thisCharacterIndexNumber)
        {
            base.Update();
        }
    }

    void Sit()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isSitting)
            {
                isSitting = true;
            }
            else
            {
                isSitting = false;
            }
        }
    }

    public override void Walk()
    {
        if (!isSitting)
        {
            base.Walk();
        }
    }

    public override void Jump()
    {
        if (!isSitting)
        {
            base.Jump();
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.otherCollider == back && col.collider.gameObject.CompareTag("missile"))
        {
            Destroy(col.gameObject);
        }
        else
        {
            base.OnCollisionEnter2D(col);
        }
    }
}
