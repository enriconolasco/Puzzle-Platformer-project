using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCanon : MonoBehaviour
{
    public GameObject missile;
    bool canShoot = true;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(missile, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z), Quaternion.identity);
            canShoot = false;
            bullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * 110);
            StartCoroutine(ShootRate());
        }
    }

    IEnumerator ShootRate()
    {
        yield return new WaitForSeconds(3);
        canShoot = true;
    }
}
