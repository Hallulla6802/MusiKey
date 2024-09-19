using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLimit : MonoBehaviour
{
    public int newOrderInLayer; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spritex") || other.CompareTag("SpriteZ"))
        {
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = newOrderInLayer;
                Debug.Log("Order in Layer changed to: " + newOrderInLayer);

                Destroy(other.gameObject, 0.5f);
            }
        }
    }
}
