using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBoundaries : MonoBehaviour
{

    public Camera _mainCamBoundaries; // C�mara principal para convertir de espacio de pantalla a espacio del mundo
    [Space]
    public Transform mouseSprite; // El objeto que sigue al mouse (un sprite o punto)
    public Transform boundaryOrigin; // Origen del l�mite para definir la zona en el mundo
    [Space]
    public Vector2 _boundarySize; // Tama�o del �rea de l�mites en el espacio del mundo
    [Space]
    private Vector2 _boundaryMin; // Coordenadas m�nimas y m�ximas del �rea
    private Vector2 _boundaryMax; 

    
    public UIManagerCJ uiManager; // UI Manager para comprobar si el juego est� en pausa

    void Start()
    {
        Cursor.visible = false; // Ocultar el cursor

        UpdateBoundaries(); // Calcular los l�mites basados en el origen y el tama�o
    }

    void Update()
    {
        // Verificar si el juego no est� pausado
        if (!uiManager.isPaused)
        {
            // Obtener la posici�n del mouse en espacio de pantalla
            Vector3 mouseScreenPosition = Input.mousePosition;

            // Calcular la posici�n Z para asegurar la distancia en el espacio 3D
            mouseScreenPosition.z = Mathf.Abs(_mainCamBoundaries.transform.position.z - mouseSprite.position.z);

            // Convertir la posici�n del mouse de pantalla a mundo
            Vector3 worldMousePos = _mainCamBoundaries.ScreenToWorldPoint(mouseScreenPosition);
            worldMousePos.z = 0; // Mantener en el plano 2D

            // Limitar la posici�n del mouse dentro de los l�mites definidos
            worldMousePos.x = Mathf.Clamp(worldMousePos.x, _boundaryMin.x, _boundaryMax.x);
            worldMousePos.y = Mathf.Clamp(worldMousePos.y, _boundaryMin.y, _boundaryMax.y);

            // Actualizar la posici�n del sprite que sigue al mouse
            mouseSprite.position = worldMousePos;
        }
    }

    void UpdateBoundaries()
    {
        // Calcular los l�mites m�nimos y m�ximos en funci�n del origen y el tama�o del �rea permitida
        _boundaryMin = (Vector2)boundaryOrigin.position - (_boundarySize / 2);
        _boundaryMax = (Vector2)boundaryOrigin.position + (_boundarySize / 2);
    }

    void OnDrawGizmos()
    {
        // Dibujar los l�mites del �rea permitida en el editor para referencia visual
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boundaryOrigin.position, _boundarySize);
    }
}
