using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUIManager : MonoBehaviour
{
    public TextMeshPro comboDisplay;
    public TextMeshPro scoreDisplay;
    public TextMeshPro missesDisplay;
    [Space]
    public Image lifeDisplay;
    public float interpolationSpeed = 5f;

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
    void Update()
    {
        float healhPercentage = Mathf.Clamp(currentHealth / maxHealth, 0f, 1.0f);
        lifeDisplay.fillAmount = Mathf.Lerp(lifeDisplay.fillAmount, healhPercentage, Time.deltaTime * interpolationSpeed);
    }
    public void UpdateUIText()
    {
        comboDisplay.text = "x" + gamMan.combos.ToString();
        scoreDisplay.text = gamMan.score.ToString();
        missesDisplay.text = gamMan.misses.ToString();
    }

    public void UpdateLifeImage()
    {
        if(lifeDisplay != null)
        {
            currentHealth = gamMan.playerLife;
            maxHealth = gamMan.playermaxLife;            
        }
    }
}
