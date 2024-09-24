using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int combos;
    public int songDuration;
    public int score;
    [Space]
    public float playerLife;
    public float playermaxLife;

    private void Start()
    {
        UpdateCombos();
    }

    public void UpdateCombos()
    {
        if(combos < 0)
        {
            combos = 0;
        }
    }
}
