using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        // Находим игрока при старте
        FindPlayer();
    }

    void Update()
    {
        // Если игрок не найден — пытаемся найти снова
        if (playerTransform == null)
        {
            FindPlayer();
        }
        else
        {
            // Двигаемся за игроком
            agent.SetDestination(playerTransform.position);

            // Передаем текущую скорость в аниматор для ходьбы
            if (animator != null)
            {
                animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
            }
        }
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }
}