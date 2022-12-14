using UnityEngine;

public class LootContainer : MonoBehaviour
{
    [SerializeField] private int randomNumber;
    [SerializeField] private bool isLooted = false;
    private Collider2D containerCollider;
    private Collider2D playerCollider;
    public GameObject emptyShelf;

    public GameObject FloatingTextController;

    public bool isPlayerTouching;

    void Awake()
    {
        containerCollider = this.gameObject.GetComponent<Collider2D>();
        
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerCollider = player.GetComponent<Collider2D>();
        }

        FloatingTextController = GameObject.Find("UI_FloatingTextController");
    }

    void FixedUpdate()
    {
        if (containerCollider.IsTouching(playerCollider))
        {
            //Debug.Log("Touching loot container");
            FloatingTextController.GetComponent<UI_FloatingTextController>().isTouchingLootContainer = true;

            isPlayerTouching = true;

            if (!isLooted && Input.GetKey(KeyCode.F))
            {
                GenerateLoot();

                Instantiate(emptyShelf, transform.position, this.transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            FloatingTextController.GetComponent<UI_FloatingTextController>().isTouchingLootContainer = false;

            isPlayerTouching = false;   
        }
    }

    void GenerateLoot()
    {
        if (!isLooted)
        {
            randomNumber = Random.Range(0, 100);

            if (randomNumber <= 70)
                Debug.Log("Common Loot");
            else if (randomNumber >70 && randomNumber <= 90)
                Debug.Log("Uncommon Loot");
            else if (randomNumber > 90 && randomNumber <= 97)
                Debug.Log("Rare Loot");
            else
                Debug.Log("Amazing Loot");

            isLooted = true;
        }
    }
}