using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    //Objetos
    [SerializeField] Player player;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    //Variaveis
    public float bulletForce = 20f;

    Vector3 mousePos;
   
    private void Update()
    {

        WeaponRotation();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //Cria um novo objeto usando o prefab do projetil e adiciona força a ele para se mover
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    // Rotaciona a arma de acordo com a posição do mouse
    void WeaponRotation()
    {
        //calcula a posição do mouse de acordo com a camera 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Faz os ajustes para ela rodar em volta do proprio eixo e execuda a correção de inclinação de acordo com o sentido que o player esta virado
        if (player.facingRight)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Quaternion.Euler(0, 0, 90);
        else
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Quaternion.Euler(0, 0, -90); 
    }


}
