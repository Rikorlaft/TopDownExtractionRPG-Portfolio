using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    [SerializeField] private GameObject lootPrefab; // Префаб лута
    [SerializeField] private float dropOffsetY = 0.5f; // Легкий подъем над землей

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Спавним лут на точке гибели противника
        if (lootPrefab != null)
        {
            Vector3 dropPosition = transform.position + Vector3.up * dropOffsetY;
            Instantiate(lootPrefab, dropPosition, Quaternion.identity);
        }

        Destroy(gameObject); // Уничтожаем врага
    }
}