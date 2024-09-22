using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythScript : MonoBehaviour
{
  
    public AudioSource audioSource;  // La m�sica que est�s reproduciendo
    public float bpm;  // El BPM de la canci�n
    public Transform[] spawnPoints;  // Los 6 puntos de spawn
    public GameObject[] noteTypes;   // Los dos tipos de notas (Prefab 1 y Prefab 2)

    public float secondsPerBeat;  // Tiempo entre beats
    public float songPosition;    // Tiempo actual de la canci�n en segundos
    public float nextNoteTime;    // Controla cu�ndo spawnear la siguiente nota

    void Start()
    {
        secondsPerBeat = 60f / bpm;  // Calcular tiempo entre beats
        nextNoteTime = secondsPerBeat;  // La primera nota deber�a aparecer en el primer beat
    }

    void Update()
    {
        // Actualizar el tiempo de la canci�n
        songPosition = audioSource.time;

        // Si es el momento de spawnear una nueva nota
        if (songPosition >= nextNoteTime)
        {
            SpawnRandomNote();
            nextNoteTime += secondsPerBeat;  // Programar la pr�xima nota
        }
    }

    void SpawnRandomNote()
    {
        // Seleccionar un spawn aleatorio entre los 6 puntos
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // Seleccionar aleatoriamente el tipo de nota (0 o 1)
        int randomNoteIndex = Random.Range(0, noteTypes.Length);
        GameObject notePrefab = noteTypes[randomNoteIndex];

        // Instanciar la nota en el punto de spawn seleccionado
        Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);

        Debug.Log("Nota spawneada en el spawn " + randomSpawnIndex + " con el tipo de nota " + randomNoteIndex);
    }
}
