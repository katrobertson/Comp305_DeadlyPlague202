using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public int state = 0;
    public float bulletForce = 20.0f;
    public Transform firePoint2;
    public Transform firePoint3;


    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (state == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if(state == 2)
        {

            GameObject bullet1 = Instantiate(bulletPrefab2, firePoint2.position, firePoint.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
            //Debug.Log(firePoint.rotation);

            GameObject bullet2 = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            //Debug.Log(firePoint.rotation);

            GameObject bullet3 = Instantiate(bulletPrefab2, firePoint3.position, firePoint.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (state == 3)
        {
            GameObject bullet = Instantiate(bulletPrefab3, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }



    }
}
