using UnityEngine;
using UnityEngine.UI;

public class UI_FloatingTextController : MonoBehaviour
{
    public Text floatingText;
    [SerializeField] private float floatingTextXOffset;
    [SerializeField] private float floatingTextYOffset;
    [SerializeField] private int floatingTextFontSize;
    private Vector2 floatingTextPosition;

    [SerializeField] private GameObject player;

    public bool isTouchingLootContainer = false;

void FixedUpdate()
    {
        // Adjust floating text position above player
        floatingTextPosition.x = player.transform.position.x + floatingTextXOffset;
        floatingTextPosition.y = player.transform.position.y + floatingTextYOffset;
        floatingText.transform.position = floatingTextPosition;

        floatingText.fontSize = floatingTextFontSize;

        if (isTouchingLootContainer)
        {
            Debug.Log("Touching Loot Container");

            floatingText.text = "Press F to loot";
        }
        else
            floatingText.text = "";
    }
}
