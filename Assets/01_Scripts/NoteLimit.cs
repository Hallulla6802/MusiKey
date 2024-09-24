using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLimit : MonoBehaviour
{
    public int newOrderInLayer;

    
    private GameManager gamMan;
    private UpdateUIManager upUI;

    private void Awake()
    {
        gamMan = FindObjectOfType<GameManager>();
        upUI = FindObjectOfType<UpdateUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpriteX") || other.CompareTag("SpriteZ"))
        {
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = newOrderInLayer;
                Debug.Log("Order in Layer changed to: " + newOrderInLayer);
                Destroy(other.gameObject, 0.2f);

                gamMan.combos = 0;
                gamMan.UpdateCombos();
                upUI.UpdateUIText();
                OnMissNote();


                
            }
        }
    }

    public void OnMissNote()
    {

        if(gamMan.playerLife < 0 )
        {
            gamMan.playerLife = 0;
        }
        else
        {
            gamMan.playerLife -= 20;
        }
    }
}
