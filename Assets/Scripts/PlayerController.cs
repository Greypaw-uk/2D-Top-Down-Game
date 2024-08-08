using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

#region Movement
    public float moveSpeed = 3f;
    private Vector2 movement;
    private bool canMove = true;
    public float rotationOffset = 90f;
#endregion

#region Weapons
    public GameObject bulletPrefab;
    public Transform firePoint;
#endregion

    public string itemName;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
             if (Input.GetKey(KeyCode.LeftShift))
                moveSpeed = 5f;
            else
                moveSpeed = 3f;

            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        RotatePlayerToMouse();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


#region Movement

    void RotatePlayerToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - rotationOffset;

        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true;
        }
    }

#endregion

#region Weapons

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

#endregion

#region Item Interaction

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider2D player)
    {
        // Add logic for picking up the item
        Debug.Log("Picked up " + itemName);
        Destroy(gameObject);
    }

#endregion
}