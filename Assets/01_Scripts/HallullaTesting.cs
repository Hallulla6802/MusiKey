using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallullaTesting : MonoBehaviour
{
    // Límites de movimiento que deseas en el eje X e Y para el mouse
    public float minX = -5f; // Límite izquierdo
    public float maxX = 5f;  // Límite derecho
    public float minY = -5f; // Límite inferior
    public float maxY = 5f;  // Límite superior

    // Posición actual controlada por el mouse
    private Vector2 currentPosition;
    public bool isPaused = false;
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
        if(!isPaused)
        {
            // Obtener el movimiento del mouse
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMouse();
        }

        void ToggleMouse()
        {
            if(isPaused)
            {
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
