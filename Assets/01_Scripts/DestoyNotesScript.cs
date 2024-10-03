using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestoyNotesScript : MonoBehaviour
{
    public AudioSource feedbackSound;

    private NoteLimit noteLimit;
    public ParticleSystem bgParticles;  
    Color bgColor;
    
    private void Awake()
    {
        noteLimit = FindObjectOfType<NoteLimit>();
        
    }
    void Update()
    {
        ChangeBGColor();
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("IsOnNote");
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            
            bgColor = Color.magenta;
            Destroy(other.gameObject);
            feedbackSound.Play();
            noteLimit.OnHitNote();
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            bgColor = Color.green;
            Destroy(other.gameObject);
            feedbackSound.Play();
            noteLimit.OnHitNote();                       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            bgColor = Color.magenta;
            Destroy(other.gameObject);
            feedbackSound.Play();

            noteLimit.OnHitNote();
            
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {  
            bgColor = Color.green;
            Destroy(other.gameObject);
            feedbackSound.Play();

            noteLimit.OnHitNote();
            
        }
    }

    void ChangeBGColor()
    {
        var main = bgParticles.main;
        main.startColor = bgColor;
    }
}
