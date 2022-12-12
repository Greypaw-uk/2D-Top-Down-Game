using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] private float ShootTimer = 1f;
    [SerializeField] private float ShootSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        if (ShootTimer >= ShootSpeed)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                ShootTimer = 0f;
            }
        }
        else
        {
            ShootTimer += 1f;
        }
    }

    void Shoot() => Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);   
}
