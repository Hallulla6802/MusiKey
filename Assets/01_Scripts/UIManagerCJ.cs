using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerCJ : MonoBehaviour
{
    public GameObject panel;
    public bool isPaused = false; 
    public AudioSource musicAudio;

private void Start()
    {
        musicAudio = GameObject.Find("MusicAudio").GetComponent<AudioSource>();
        isPaused = false;
        panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {


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
        
    }

    public void ActivarPausa()
    {
        panel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;

    }

    public void DesactivarPausa()
    {
        panel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
