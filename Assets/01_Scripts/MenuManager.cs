using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToSong1()
    {
        SceneManager.LoadScene("01_Song1");
    }
}
