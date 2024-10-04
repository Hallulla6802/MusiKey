using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovementScript : MonoBehaviour
{
    private float noteSpeed;  // La velocidad que la nota necesita para llegar en el tiempo correcto
    void Start()
    {
        // Encontrar el objeto llamado "BoundariesSprites" (la grilla) para calcular la distancia
        GameObject boundariesObj = GameObject.Find("BoundariesSprites");
        if (boundariesObj != null)
        {
            Transform targetGrid = boundariesObj.transform;  // Usar el Transform de BoundariesSprites para la distancia
            // Encontrar el script RhythScript
            RhythScript rhythScript = FindObjectOfType<RhythScript>();

            // Calcular la distancia desde la posici�n inicial de la nota hasta la grilla
            float distanceToTravel = Vector3.Distance(transform.position, targetGrid.position);
            // Calcular el tiempo que la nota debe tardar en llegar (segundos por beat)
            float timeToReachGrid = rhythScript.secondsPerBeat;
            // Calcular la velocidad necesaria para llegar en ese tiempo
            noteSpeed = distanceToTravel / timeToReachGrid;
        }
        else
        {
            Debug.LogError("No se encontr� un objeto llamado 'BoundariesSprites'. Aseg�rate de que el nombre sea correcto.");
            return;
        }
    }

    void Update()
    {
        // Aqu� no movemos la nota directamente hacia la grilla, sino que usamos la velocidad calculada
        // para que se mueva hacia adelante con la velocidad correcta
        transform.Translate(Vector3.back * noteSpeed * Time.deltaTime);
        
    }
}
