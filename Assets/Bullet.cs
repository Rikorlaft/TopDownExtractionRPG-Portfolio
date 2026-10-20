using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public float lifeTime = 3f;

    void Start()
    {
        // Уничтожаем пулю через 3 секунды, если она ни во что не попала
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Движение пули вперёд
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, попала ли пуля во врага
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Уничтожаем пулю при попадании
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment") || other.CompareTag("Wall"))
        {
            // Уничтожаем пулю при попадании в стены или препятствия
            Destroy(gameObject);
        }
    }
}