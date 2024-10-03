using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyCircles : MonoBehaviour
{
    #region OldCode
    /* public Transform[] squares;         // Array of squares (aligned with spawners)
    public LayerMask prefabLayerMask;   // The layer for the prefab sprites
    public float maxDistance = 5f;      // Distance at which the square will be fully transparent
    public float finalTransparency = 1f; // Final transparency (0 to 1)
    public Color rayColor = Color.green; // Color for the raycast gizmos

    private SpriteRenderer[] squareRenderers;  // SpriteRenderer components for the squares

    void Start()
    {
        // Initialize the array of SpriteRenderers for each square
        squareRenderers = new SpriteRenderer[squares.Length];

        for (int i = 0; i < squares.Length; i++)
        {
            squareRenderers[i] = squares[i].GetComponent<SpriteRenderer>();

            if (squareRenderers[i] == null)
            {
                Debug.LogError("No SpriteRenderer found on the square object at index " + i);
            }

            // Set squares to fully transparent at the start
            Color transparentColor = squareRenderers[i].color;
            transparentColor.a = 0f;  // Fully transparent
            squareRenderers[i].color = transparentColor;
        }
    }

    void Update()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            Transform square = squares[i];

            // Raycast from the square in the forward direction (Z-axis)
            Ray ray = new Ray(square.position, square.forward); // Adjust direction if necessary
            RaycastHit hit;

            // Check if the raycast hits a prefab within the max distance
            if (Physics.Raycast(ray, out hit, maxDistance, prefabLayerMask))
            {
                // Calculate opacity based on the distance to the hit object (prefab)
                float distance = hit.distance;
                float opacity = Mathf.Clamp01(finalTransparency * (1f - (distance / maxDistance)));

                // Debug to check the raycast hit and distance
                Debug.Log($"Square {i} hit {hit.collider.name} at distance {distance}. Setting opacity to {opacity}.");

                // Update square's opacity
                Color newColor = squareRenderers[i].color;
                newColor.a = opacity;
                squareRenderers[i].color = newColor;
            }
            else
            {
                // If no prefab is hit, keep the square fully transparent
                Color transparentColor = squareRenderers[i].color;
                transparentColor.a = 0f;
                squareRenderers[i].color = transparentColor;

                // Debug to check if no hit occurred
                Debug.Log($"Square {i} did not hit any prefab. Keeping opacity at 0.");
            }
        }
    }

    // Draw the raycast using Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;

        if (squares == null || squares.Length == 0)
            return;

        // Draw a ray for each square in the forward direction
        foreach (Transform square in squares)
        {
            if (square != null)
            {
                Vector3 direction = square.forward * maxDistance; // The direction and length of the ray
                Gizmos.DrawRay(square.position, direction);       // Draw the ray
            }
        }
    } */
    #endregion oldCode
    public GameObject objetoAScalar;  // El objeto que será escalado
    public float escalaMin = 0.2f;  // Tamaño mínimo de escala
    public float escalaMax = 1.2f;    // Tamaño máximo de escala
    public float distanciaMin = 1f;  // Distancia mínima para aplicar la escala más grande
    public float distanciaMax = 12f; // Distancia máxima para aplicar la escala más pequeña
    public LayerMask layerMask; // Capa de los objetos que pueden ser detectados por el raycast
    SpriteRenderer spRenderer;
    void Start()
    {
        spRenderer = objetoAScalar.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Lanzar un raycast hacia adelante desde la posición del objeto actual
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Si el raycast detecta un objeto en el layer especificado
        if (Physics.Raycast(ray, out hit, distanciaMax, layerMask))
        {
            // Obtener la distancia al objeto detectado
            float distancia = hit.distance;

            // Normalizar la distancia entre 0 y 1
            float factorEscala = Mathf.InverseLerp(distanciaMax, distanciaMin, distancia);

            // Aplicar la escala al objeto, interpolando entre la escala mínima y máxima
            float escalaActual = Mathf.Lerp(escalaMin, escalaMax, factorEscala);
            objetoAScalar.transform.localScale = new Vector3(escalaActual, escalaActual, escalaActual);
            spRenderer.enabled = true;
        }
        else
        {
            // Si no se detecta nada, puedes opcionalmente hacer que el objeto vuelva a su tamaño mínimo
            objetoAScalar.transform.localScale = new Vector3(escalaMin, escalaMin, escalaMin);
            spRenderer.enabled = false;
        }
    }
}

