using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 0, -10);    // Default offset for 2D games

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}