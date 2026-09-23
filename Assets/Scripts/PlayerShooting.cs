using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float projectileSpeed = 10f;
    public float fireCooldown = 0.25f;
    public float firePointDistance = 0.6f;
    public float nextFireTime;
    private Vector2 shootDirection = Vector2.right;

    void Update()
    {
        Vector2 inputDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (inputDirection != Vector2.zero)
        {
            shootDirection = inputDirection.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
        void Shoot()
        {
            firePoint.localPosition =
                shootDirection * firePointDistance;

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

            projectileRb.linearVelocity = shootDirection * projectileSpeed;

            Destroy(projectile, 3f);


        }
    }
}
