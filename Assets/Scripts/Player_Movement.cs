using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Sprite
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Rotate to face cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall")) 
        {
            rb.velocity = Vector3.zero;
            Debug.Log("Walked into wall");    
        }
    }
}
