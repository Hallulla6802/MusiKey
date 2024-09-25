using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioCountDown : MonoBehaviour
{
    public AudioSource audioSource;  // El AudioSource que contiene la música
    public TextMeshPro countdownText;  // El TextMeshPro para texto en objetos 3D
    public float timeRemaining;  // Tiempo restante de la música
    private bool isPaused = false;  // Si la música está en pausa o no

    void Start()
    {
        timeRemaining = audioSource.clip.length;  // Duración total del clip de audio
    }

    void Update()
    {
        // Solo actualizamos si no está en pausa
        if (!isPaused && audioSource.isPlaying)
        {
            timeRemaining = audioSource.clip.length - audioSource.time;
            UpdateCountdownText(timeRemaining);
        }
        else if (isPaused)
        {
            UpdateCountdownText(timeRemaining);  // Continuar mostrando el tiempo restante aunque esté en pausa
        }
    }

    // Método para actualizar el texto del tiempo restante
    void UpdateCountdownText(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);  // Minutos restantes
        int seconds = Mathf.FloorToInt(timeRemaining % 60);  // Segundos restantes
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Formato MM:SS
    }

    // Método para pausar la música
    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();  // Pausa la música
            isPaused = true;  // Marca el estado de pausa
        }
    }

    // Método para reanudar la música
    public void ResumeMusic()
    {
        if (isPaused)
        {
            audioSource.Play();  // Reanuda la música
            isPaused = false;  // Marca que ya no está en pausa
        }
    }
}
