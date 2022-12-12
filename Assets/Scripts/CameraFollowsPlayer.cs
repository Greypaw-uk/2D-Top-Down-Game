using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float OffsetX = 0f;
    [SerializeField] private float OffsetY = 0f;
    [SerializeField] private float Offsetz = -10f;

    // Set camera to follow player
    void FixedUpdate() => transform.position = new Vector3 (player.transform.position.x + OffsetX, player.transform.position.y + OffsetY, Offsetz);
}
