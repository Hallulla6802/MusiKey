using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour

{
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("00_Menu");
    }
 
    public void GoToSong1()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("01_Song1");
    }

    public void GoToSong2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("02_Song2");
    }

    public void QuitGame()
    {
        Application.Quit(1);
    }
}
