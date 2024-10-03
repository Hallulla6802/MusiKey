using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallullaTesting : MonoBehaviour
{
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
