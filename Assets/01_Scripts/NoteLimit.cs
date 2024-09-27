using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLimit : MonoBehaviour
{
    public int newOrderInLayer;
    public int lifeToTake;
    public int notesScores;


    [SerializeField] private float recuperativeAmount = 30f;
    private GameManager gamMan;
    private UpdateUIManager upUI;


    private void Awake()
    {
        gamMan = FindObjectOfType<GameManager>();
        upUI = FindObjectOfType<UpdateUIManager>();
    }

    private void OnTriggerExit(Collider other)
    {
 
        gamMan.combos = 0;
        gamMan.UpdateCombos();
        upUI.UpdateUIText();
        OnMissNote();
        Destroy(other.gameObject);

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
                

            }
        }
    }

    public void OnMissNote()
    {

        if(gamMan.playerLife < 0 )
        {
            gamMan.playerLife = 0;
            upUI.UpdateLifeImage();
            upUI.UpdateUIText();
        }
        else
        {
            gamMan.playerLife -= lifeToTake;
            gamMan.misses++;
            upUI.UpdateLifeImage();
            upUI.UpdateUIText();
        }
    }

    public void OnHitNote()
    {
        AddScore();

        if (gamMan.playerLife == gamMan.playermaxLife)
        {
            gamMan.playerLife = gamMan.playermaxLife;
            upUI.UpdateLifeImage();
        }
        else
        {
            gamMan.playerLife += recuperativeAmount;
            upUI.UpdateLifeImage();
        }
    }

    public void AddScore()
    {
       
         gamMan.score += notesScores;
         gamMan.score += notesScores * gamMan.combos;
        
    }
}
