using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUIManager : MonoBehaviour
{
    public TextMeshPro comboDisplay;


    private GameManager gamMan;

    private void Start()
    {
        gamMan = FindObjectOfType<GameManager>();
        UpdateUIText();
    }

    public void UpdateUIText()
    {
        comboDisplay.text = "x" + gamMan.combos.ToString();
    }
}
