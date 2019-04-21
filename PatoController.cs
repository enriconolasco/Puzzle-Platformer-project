using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PatoController : CharacterController
{
    bool isFlying;
    float fuel;
    public GameObject missile;
    bool hasShot;

    public override void Start()
    {
        moveSpeed = 60.0f;
        jumpHeight = 25.0f;
        characterMass = 120.0f;
        characterStrength = 1;
        thisCharacterIndexNumber = 2;
        fuel = 10.0f;
        isFlying = false;
        hasShot = false;
        base.Start();
    }

    public override void Update()
    {
        if (gm.selectedCharacterIndex == thisCharacterIndexNumber)
        {
            if (hasShot == false)
            {
                FlyManager();
            }
            if (Input.GetKeyDown(KeyCode.F) && hasShot == false && fuel > 5.0f && isFlying == false)
            {
                Shoot();
            }
            base.Update();
        }
    }

    void Shoot()
    {
        if (facingForward)
        {
            GameObject bullet = Instantiate(missile, new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 200);
            hasShot = true;
            fuel -= 5.0f;
            moveSpeed += 30.0f;
        }
        else
        {
            GameObject bullet = Instantiate(missile, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * 200);
            hasShot = true;
            fuel -= 5.0f;
            moveSpeed += 30.0f;
        }
    }

    void Fly()
    {
            if (isFlying)
            {
                rb.gravityScale = 0;
            }
            if (!isFlying)
            {
                rb.gravityScale = 1.0f;
            }
    }

    void FlyManager()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isFlying == false && fuel > 0)
            {
                isFlying = true;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z);
            }
            else
            {
                isFlying = false;
            }
        }

        Fly();

        if (isFlying)
        {
            fuel -= Time.deltaTime;
        }

        if (fuel <= 0)
        {
            isFlying = false;
        }
    }
}
