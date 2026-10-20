using UnityEngine;

public class LootItem : MonoBehaviour
{
    [SerializeField] private string itemName = "Ценный артефакт";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Находим инвентарь на игроке
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                inventory.AddLoot(1);
            }

            Destroy(gameObject); // Удаляем предмет со сцены
        }
    }
}