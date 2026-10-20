using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRate = 1.0f;     // Урон раз в 1 секунду
    public float attackDistance = 1.5f; // Расстояние, на котором враг атакует

    private float nextAttackTime = 0f;
    private Transform playerTransform;
    private PlayerHealth playerHealth;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (playerTransform == null || playerHealth == null) return;

        // Считаем дистанцию до игрока
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Если враг подошел достаточно близко и прошло время перезарядки
        if (distance <= attackDistance && Time.time >= nextAttackTime)
        {
            playerHealth.TakeDamage(attackDamage);
            nextAttackTime = Time.time + attackRate;
        }
    }
}