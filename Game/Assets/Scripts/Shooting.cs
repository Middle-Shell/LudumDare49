using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject lumenPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ShootLumen();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, this.gameObject.GetComponent<PlayerMovement>().Hand.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce * (this.gameObject.GetComponent<PlayerMovement>().coof), ForceMode2D.Impulse);
    }
    void ShootLumen()
    {
        GameObject bullet = Instantiate(lumenPrefab, firePoint.position, this.gameObject.GetComponent<PlayerMovement>().Hand.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 2f * (this.gameObject.GetComponent<PlayerMovement>().coof), ForceMode2D.Impulse);
    }
}