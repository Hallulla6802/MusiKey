using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerCJ : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelGameOver;
    public GameObject panelWin;
    public bool isPaused = false; 
    public AudioSource musicAudio;
    public int scene;
    public int nextScene;

    public GameManager gameManager;
    public AudioCountDown audiocountdown;

private void Start()
    {
        musicAudio = GameObject.Find("MusicAudio").GetComponent<AudioSource>();
        isPaused = false;
        panel.SetActive(false);
        panelGameOver.SetActive(false);
        panelWin.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !panelGameOver.activeSelf && !panelWin.activeSelf)
        {
            Cursor.visible = true;

            if (isPaused)
            {
                musicAudio.UnPause();
                DesactivarPausa();
            }
            else
            {
                musicAudio.Pause();
                ActivarPausa();
            }
        }

        if (gameManager.playerLife <= 0)
        {
            ActivarGameOver();
        }

        if (gameManager.playerLife > 0 && audiocountdown.timeRemaining <= 0.1)
        {
            ActivarWin();
            
        }


    }

   

    public void ActivarPausa()
    {
        panel.SetActive(true);
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

    }

    public void DesactivarPausa()
    {
        panel.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        
    }

    public void ActivarGameOver()
    {
        panelGameOver.SetActive(true);
        musicAudio.Pause();
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void ActivarWin()
    {
        panelWin.SetActive(true);
        musicAudio.Pause();
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    
    



}
