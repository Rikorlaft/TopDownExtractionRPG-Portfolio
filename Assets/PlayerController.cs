using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;

    [Header("Shooting Setup")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Weapon Settings")]
    public float fireRate = 0.15f;
    private float nextFireTime = 0f;

    private Rigidbody rb;
    private Vector3 movementInput;
    private Animator animator;

    void Start()
    {
        // Получаем ссылку на Rigidbody при старте
        rb = GetComponent<Rigidbody>();

        // <--- Добавили поиск аниматора на дочернем объекте
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 1. Считываем ввод с клавиатуры
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementInput = new Vector3(horizontal, 0f, vertical).normalized;

        // 2. Поворот за мышкой
        RotateToMouse();

        // 3. Стрельба с задержкой
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        // <--- Добавляем передачу скорости в Animator
        if (animator != null)
        {
            // Если движение есть, передаем 1 (или скорость), если стоим — 0
            float currentSpeed = movementInput.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
    }

    void FixedUpdate()
    {
        // 4. Движение через физику Rigidbody (теперь персонаж будет упираться в стены и коллайдеры)
        Vector3 moveVelocity = movementInput * speed;
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void RotateToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 targetPoint = ray.GetPoint(rayDistance);
            Vector3 lookDirection = targetPoint - transform.position;
            lookDirection.y = 0f;

            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}