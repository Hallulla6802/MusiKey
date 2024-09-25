using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int combos;
    public int score;
    public int misses;
    [Space]
    public float playerLife;
    public float playermaxLife;

    private void Start()
    {
        misses = 0;
        score = 0;
        combos = 0;

        UpdateCombos();
    }

    public void UpdateCombos()
    {
        if(combos < 0)
        {
            combos = 0;
        }
    }

    private void Update()
    {
        if (playerLife > playermaxLife)
        {
            playerLife = playermaxLife;
        }

        if(misses < 0)
        {
            misses = 0;
        }
    }
}
