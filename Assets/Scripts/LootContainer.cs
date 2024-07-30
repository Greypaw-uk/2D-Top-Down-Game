using UnityEngine;

public class LootContainer : MonoBehaviour
{
    public GameObject[] lootItems;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Loot();
            Destroy(gameObject);
        }
    }

    void Loot()
    {
        // Add logic to spawn loot items
        int randomIndex = Random.Range(0, lootItems.Length);
        Instantiate(lootItems[randomIndex], transform.position, Quaternion.identity);
    }
}