using UnityEngine;
using TMPro;

public class ExtractionZone : MonoBehaviour
{
    [SerializeField] private float extractionTime = 4f;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI winLootText; // Ссылка на текст добычи на экране победы

    private float currentTimer;
    private bool isPlayerInZone = false;

    private void Start()
    {
        currentTimer = extractionTime;
        if (timerText != null) timerText.gameObject.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInZone)
        {
            currentTimer -= Time.deltaTime;
            if (timerText != null)
                timerText.text = $"Extraction: {currentTimer:F1} sec";

            if (currentTimer <= 0f)
            {
                WinGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            if (timerText != null) timerText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            currentTimer = extractionTime;
            if (timerText != null) timerText.gameObject.SetActive(false);
        }
    }

    private void WinGame()
    {
        if (timerText != null) timerText.gameObject.SetActive(false);

        // Находим игрока и его инвентарь
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerInventory inventory = player.GetComponent<PlayerInventory>();
            if (inventory != null && winLootText != null)
            {
                winLootText.text = $"Items successfully extracted: {inventory.totalLootCount}";
            }
        }

        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}