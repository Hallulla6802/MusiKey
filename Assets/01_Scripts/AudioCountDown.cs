using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioCountDown : MonoBehaviour
{
    public AudioSource audioSource;  // El AudioSource que contiene la m�sica
    public TextMeshPro countdownText;  // El TextMeshPro para texto en objetos 3D
    public float timeRemaining;  // Tiempo restante de la m�sica
    private bool isPaused = false;  // Si la m�sica est� en pausa o no

    void Start()
    {
        timeRemaining = audioSource.clip.length;  // Duraci�n total del clip de audio
    }

    void Update()
    {
        // Solo actualizamos si no est� en pausa
        if (!isPaused && audioSource.isPlaying)
        {
            timeRemaining = audioSource.clip.length - audioSource.time;
            UpdateCountdownText(timeRemaining);
        }
        else if (isPaused)
        {
            UpdateCountdownText(timeRemaining);  // Continuar mostrando el tiempo restante aunque est� en pausa
        }
    }

    // M�todo para actualizar el texto del tiempo restante
    void UpdateCountdownText(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);  // Minutos restantes
        int seconds = Mathf.FloorToInt(timeRemaining % 60);  // Segundos restantes
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Formato MM:SS
    }

    // M�todo para pausar la m�sica
    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();  // Pausa la m�sica
            isPaused = true;  // Marca el estado de pausa
        }
    }

    // M�todo para reanudar la m�sica
    public void ResumeMusic()
    {
        if (isPaused)
        {
            audioSource.Play();  // Reanuda la m�sica
            isPaused = false;  // Marca que ya no est� en pausa
        }
    }
}
