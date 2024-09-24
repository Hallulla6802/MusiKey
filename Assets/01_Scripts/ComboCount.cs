using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
    private GameManager gamMan;
    private UpdateUIManager upUI;

    private HashSet<Collider> triggeredSprites = new HashSet<Collider>();  // Track sprites that have triggered the combo

    private void Awake()
    {
        gamMan = FindObjectOfType<GameManager>();
        upUI = FindObjectOfType<UpdateUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggeredSprites.Contains(other) && IsCorrectKeyInput(other))
        {
            AddCombo(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!triggeredSprites.Contains(other) && IsCorrectKeyInput(other))
        {
            AddCombo(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the sprite from the HashSet so the combo can be triggered again for the next sprite
        if (triggeredSprites.Contains(other))
        {
            triggeredSprites.Remove(other);
        }
    }

    private bool IsCorrectKeyInput(Collider other)
    {
        // Check for the correct key input based on the tag of the sprite
        return (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X)) ||
               (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z));
    }

    private void AddCombo(Collider other)
    {
        gamMan.combos++;
        gamMan.UpdateCombos();
        upUI.UpdateUIText();

        // Add the sprite to the HashSet to prevent it from triggering multiple times
        triggeredSprites.Add(other);
    }
}
