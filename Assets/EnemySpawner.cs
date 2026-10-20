using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Настройки спавна")]
    public GameObject enemyPrefab;       // Префаб твоего зомби
    public float spawnInterval = 8f;     // Интервал между волнами в секундах (сделали медленнее)

    private Transform[] spawnPoints;

    void Start()
    {
        // Автоматически находим все дочерние точки спавна
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }

        // Запускаем бесконечный цикл спавна волн
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Ждем нужное количество секунд перед следующей волной
            yield return new WaitForSeconds(spawnInterval);

            // Спавним зомби на каждой точке
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (enemyPrefab != null && spawnPoint != null)
                {
                    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                }
            }
        }
    }
}