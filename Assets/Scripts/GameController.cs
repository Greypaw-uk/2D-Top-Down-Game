using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;

    public Text floatingText;
    public float floatingTextXOffset;
    public float floatingTextYOffset;
    public int floatingTextFontSize;
    public Vector2 floatingTextPosition;

    public GameObject player;

    public bool isTouchingLootContainer = false;

    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void FixedUpdate()
    {
        // Adjust floating text position above player
        floatingTextPosition.x = player.transform.position.x + floatingTextXOffset;
        floatingTextPosition.y = player.transform.position.y + floatingTextYOffset;
        floatingText.transform.position = floatingTextPosition;

        if (isTouchingLootContainer)
        {
            Debug.Log("Touching Loot Container");

            floatingText.text = "Press F to loot";
        }
        else
            floatingText.text = "";
    }
}
