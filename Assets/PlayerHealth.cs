using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider; // Ссылка на UI слайдер

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public GameObject losePanel;

    void Die()
    {
        Debug.Log("Игрок погиб!");
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
        Time.timeScale = 0f; // Останавливаем игру при смерти
    }
}