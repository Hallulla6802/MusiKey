using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUIManager : MonoBehaviour
{
    public TextMeshPro comboDisplay;

    public Image lifeDisplay;

    private float currentHealth;
    private float maxHealth;

    private GameManager gamMan;

    private void Start()
    {
        gamMan = FindObjectOfType<GameManager>();

        currentHealth = gamMan.playerLife;
        maxHealth = gamMan.playermaxLife;

        UpdateUIText();
    }

    public void UpdateUIText()
    {
        comboDisplay.text = "x" + gamMan.combos.ToString();
    }

    public void UpdateLifeImage()
    {
        if(lifeDisplay != null)
        {
            currentHealth = gamMan.playerLife;
            maxHealth = gamMan.playermaxLife;

            float healhPercentage = Mathf.Clamp(currentHealth / maxHealth, 0f, 1.0f);

            lifeDisplay.fillAmount = healhPercentage;
        }
    }
}
