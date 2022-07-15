using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    [SerializeField] Player player;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    Vector3 mousePos;
   

    private void Start()
    {

    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(player.facingRight)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position)* Quaternion.Euler(0,0,90);
        else
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Quaternion.Euler(0, 0, -90);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}
