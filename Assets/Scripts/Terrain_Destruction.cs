using UnityEngine;

public class Terrain_Destruction : MonoBehaviour
{
    [SerializeField] private float Health = 50f;
    public GameObject DestroyedObject;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Instantiate(DestroyedObject, transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D() => this.Health = Health - 10;
}
