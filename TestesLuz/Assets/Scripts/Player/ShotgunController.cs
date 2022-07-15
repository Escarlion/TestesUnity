using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    [SerializeField] Camera cam;
    
    Player player;
    Rigidbody2D rb;

    Vector2 mousePos, lookDir;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    float angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = gameObject.GetComponentInParent<Player>();
    }
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        lookDir = mousePos - rb.position;
        if (player.facingRight)
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        else
            angle = Mathf.Atan2(lookDir.y * -1, lookDir.x * -1) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}
