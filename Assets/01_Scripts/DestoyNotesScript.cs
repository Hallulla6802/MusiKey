using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestoyNotesScript : MonoBehaviour
{   
    private Vector3 boxSize = new Vector3(1.4f, 1.4f, 1.8f);
    public AudioSource feedbackSound;
    private NoteLimit noteLimit;
    public ParticleSystem bgParticles; 
    private ParticleSystem.Particle[] particles; 
    private Color bgColor;

    private void Awake()
    {
        noteLimit = FindObjectOfType<NoteLimit>();
        bgColor = Color.white;
    }
    void Update()
    {
        CambiarColorParticulas();
        if (Input.GetKeyDown(KeyCode.X))
        {
            CheckNoteHit("SpriteX");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            CheckNoteHit("SpriteZ");
        }
    }
    private void CheckNoteHit(string tag)
    {
        Vector3 boxCenter = transform.position;
        Collider[] hitColliders = Physics.OverlapBox(boxCenter, boxSize / 2, Quaternion.identity); // Dividimos por 2 porque OverlapBox usa el tamaño completo 

        foreach (var collider in hitColliders)
        {   
            Debug.Log("Collider detected: " + collider.name);
            if (collider.CompareTag(tag))
            {
                
                if (tag == "SpriteX")
                {
                    bgColor = Color.magenta;
                }
                else if (tag == "SpriteZ")
                {
                    bgColor = Color.green;
                }

                Destroy(collider.gameObject);
                feedbackSound.Play();
                noteLimit.OnHitNote();
                break; 
            }
        }
    }
    void CambiarColorParticulas()
    {
        // Obtén la cantidad de partículas activas
        int cantidadParticulas = bgParticles.particleCount;

        // Si no hay partículas, no hace nada
        if (cantidadParticulas == 0)
            return;

        // Crea un array para almacenar las partículas
        if (particles == null || particles.Length < cantidadParticulas)
        {
            particles = new ParticleSystem.Particle[cantidadParticulas];
        }

        // Obtén las partículas activas en el sistema
        bgParticles.GetParticles(particles);

        // Cambia el color de cada partícula
        for (int i = 0; i < cantidadParticulas; i++)
        {
            particles[i].startColor = bgColor;
        }

        // Aplica los cambios al sistema de partículas
        bgParticles.SetParticles(particles, cantidadParticulas);
    }
    private float detectionRadius = 0.7f; // Ajusta este valor según el rango que estés utilizando

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // Cambia el color según tu preferencia
        Gizmos.DrawWireCube(transform.position, boxSize); // Dibuja un cubo de alambre
    }
}
