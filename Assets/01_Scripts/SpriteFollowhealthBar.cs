using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFollowhealthBar : MonoBehaviour
{
    public Image healthBar;  // La imagen de la barra de vida en modo "Filled"
    public RectTransform spriteToFollow;  // El sprite que seguirá el extremo de la barra de vida
    
    private void Update()
    {
        if (healthBar != null && spriteToFollow != null)
        {
            // Obtén el ancho de la barra de vida
            float barWidth = healthBar.rectTransform.rect.width;

            // Calcula la nueva posición en el eje X para el sprite
            // El fillAmount de la barra va de 0 a 1, así que multiplicamos por el ancho total de la barra
            Vector3 newPosition = spriteToFollow.localPosition;
            newPosition.x = (healthBar.fillAmount * barWidth) - (barWidth / 2);

            // Actualiza la posición del sprite
            spriteToFollow.localPosition = newPosition;
        }
    }
}
