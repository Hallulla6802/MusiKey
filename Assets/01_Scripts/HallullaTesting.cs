using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallullaTesting : MonoBehaviour
{
    // Límites de movimiento que deseas en el eje X e Y para el mouse
    public float minX = -3.6f; // Límite izquierdo
    public float maxX = 3.6f;  // Límite derecho
    public float minY = -3.6f; // Límite inferior
    public float maxY = 3.6f;  // Límite superior

    public float mouseSensi = 100f;
    // Posición actual controlada por el mouse
    private Vector2 currentPosition;
    void Start()
    {
        // Bloquear el cursor en el centro y hacerlo invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Inicializa la posición actual
        currentPosition = Vector2.zero;
    }

    void Update()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

        // Actualizar la posición según el movimiento del mouse
        currentPosition.x += mouseX;
        currentPosition.y += mouseY;

        // Restringir el movimiento a los límites definidos
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // Aquí puedes usar la nueva posición del mouse para mover objetos o cámaras
        // Por ejemplo, mover una cámara o un objeto en el mundo según los límites:
        transform.position = new Vector3(currentPosition.x, currentPosition.y, transform.position.z);

        // Si solo quieres confinar el mouse visualmente en la UI, podrías usar esto para actualizar algún elemento en pantalla.
        
    }
}
