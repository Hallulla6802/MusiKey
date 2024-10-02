using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBoundaries : MonoBehaviour
{

    public Camera _mainCamBoundaries; // Cámara principal para convertir de espacio de pantalla a espacio del mundo
    [Space]
    public Transform mouseSprite; // El objeto que sigue al mouse (un sprite o punto)
    public Transform boundaryOrigin; // Origen del límite para definir la zona en el mundo
    [Space]
    public Vector2 _boundarySize; // Tamaño del área de límites en el espacio del mundo
    [Space]
    private Vector2 _boundaryMin; // Coordenadas mínimas y máximas del área
    private Vector2 _boundaryMax; 

    
    public UIManagerCJ uiManager; // UI Manager para comprobar si el juego está en pausa

    void Start()
    {
        Cursor.visible = false; // Ocultar el cursor

        UpdateBoundaries(); // Calcular los límites basados en el origen y el tamaño
    }

    void Update()
    {
        // Verificar si el juego no está pausado
        if (!uiManager.isPaused)
        {
            // Obtener la posición del mouse en espacio de pantalla
            Vector3 mouseScreenPosition = Input.mousePosition;

            // Calcular la posición Z para asegurar la distancia en el espacio 3D
            mouseScreenPosition.z = Mathf.Abs(_mainCamBoundaries.transform.position.z - mouseSprite.position.z);

            // Convertir la posición del mouse de pantalla a mundo
            Vector3 worldMousePos = _mainCamBoundaries.ScreenToWorldPoint(mouseScreenPosition);
            worldMousePos.z = 0; // Mantener en el plano 2D

            // Limitar la posición del mouse dentro de los límites definidos
            worldMousePos.x = Mathf.Clamp(worldMousePos.x, _boundaryMin.x, _boundaryMax.x);
            worldMousePos.y = Mathf.Clamp(worldMousePos.y, _boundaryMin.y, _boundaryMax.y);

            // Actualizar la posición del sprite que sigue al mouse
            mouseSprite.position = worldMousePos;
        }
    }

    void UpdateBoundaries()
    {
        // Calcular los límites mínimos y máximos en función del origen y el tamaño del área permitida
        _boundaryMin = (Vector2)boundaryOrigin.position - (_boundarySize / 2);
        _boundaryMax = (Vector2)boundaryOrigin.position + (_boundarySize / 2);
    }

    void OnDrawGizmos()
    {
        // Dibujar los límites del área permitida en el editor para referencia visual
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boundaryOrigin.position, _boundarySize);
    }
}
