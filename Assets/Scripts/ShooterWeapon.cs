using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f; // Éä»÷¼ä¸ôÎª0.2Ãë
    private bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        isShooting = true;
        while (Input.GetButton("Fire1"))
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
        isShooting = false;
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
