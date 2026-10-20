using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Ссылка на объект игрока, за которым нужно следить
    public Transform target;

    // Смещение камеры относительно игрока (например, выше и чуть позади)
    public Vector3 offset = new Vector3(0f, 10f, -5f);

    // Скорость сглаживания движения
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Точка, куда камера должна приехать
        Vector3 desiredPosition = target.position + offset;

        // Плавный перетор между текущей позицией и нужной (Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Обновляем позицию камеры
        transform.position = smoothedPosition;
    }
}