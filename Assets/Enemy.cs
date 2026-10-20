using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Метод получение урона
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // Если здоровье закончилось — враг погибает
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Пока просто уничтожаем объект
        Destroy(gameObject);
    }
}