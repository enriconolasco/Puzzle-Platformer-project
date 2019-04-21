using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PugController : CharacterController {

    public override void Start()
    {
        thisCharacterIndexNumber = 1;
        characterStrength = 3;
        jumpHeight = 25.0f;
        characterMass = 120.0f;
        base.Start();
    }

    public override void Update()
    {
        if (gm.selectedCharacterIndex == thisCharacterIndexNumber)
        {
            base.Update();
        }
    }

    public override void Walk()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            moveSpeed = 60.0f;
        }
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            moveSpeed += Time.deltaTime * 20;
        }
            base.Walk();
    }

}
