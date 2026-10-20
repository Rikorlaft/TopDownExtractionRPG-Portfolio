using UnityEngine;
using TMPro; // Потребуется для отображения счетчика в UI

public class PlayerInventory : MonoBehaviour
{
    [Header("Loot Data")]
    public int totalLootCount = 0;

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI lootCounterText;

    private void Start()
    {
        UpdateLootUI();
    }

    public void AddLoot(int amount = 1)
    {
        totalLootCount += amount;
        Debug.Log($"Inventory: {totalLootCount}");
        UpdateLootUI();
    }

    private void UpdateLootUI()
    {
        if (lootCounterText != null)
        {
            lootCounterText.text = $"Loot: {totalLootCount}";
        }
    }
}