using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerMovement player;
    public float fireRate = 2.5f;
    float timeToShoot = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToShoot)
        {
            Shoot();
            player.animator.SetBool("Shoot", true);
            timeToShoot = Time.time + 1 / fireRate;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            player.animator.SetBool("Shoot", false);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            double y = firePoint.position.y - 0.83;
            firePoint.position = new Vector3(firePoint.position.x, (float) y, 0);
        }
        if (Input.GetButtonUp("Crouch"))
        {
            double y = firePoint.position.y + 0.83;
            firePoint.position = new Vector3(firePoint.position.x,(float) y, 0);
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            double y = firePoint.position.y - 0.1;
            firePoint.position = new Vector3(firePoint.position.x, (float)y, 0);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            double y = firePoint.position.y + 0.1;
            firePoint.position = new Vector3(firePoint.position.x, (float)y, 0);
        }

    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
