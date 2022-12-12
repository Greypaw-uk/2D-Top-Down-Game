using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 200.0f;
    private Vector2 mousePosition;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get mouse position
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set start position
        Vector3 direction = mousePosition - rb.position;

        // Move in direction of mouse position
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * (speed * Time.fixedDeltaTime);
    }

    // Remove bullet upon exiting camera view
    void OnBecameInvisible() => Destroy(gameObject);

    // Remove bullet when colliding with another object
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag != "Player")
            Destroy(gameObject);
    }
}
