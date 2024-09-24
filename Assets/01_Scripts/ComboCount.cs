using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
    private GameManager gamMan;
    private UpdateUIManager upUI;

    private void Awake()
    {
        gamMan = FindObjectOfType<GameManager>();
        upUI = FindObjectOfType<UpdateUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X)) || (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z)))
        {
            gamMan.combos++;
            gamMan.UpdateCombos();
            upUI.UpdateUIText();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X)) || (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z)))
        {
            gamMan.combos++;
            gamMan.UpdateCombos();
            upUI.UpdateUIText();
        }
    }
}
