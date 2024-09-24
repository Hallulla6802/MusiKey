using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyNotesScript : MonoBehaviour
{
    public AudioSource feedbackSound;

    private NoteLimit noteLimit;

    private void Awake()
    {
        noteLimit = FindObjectOfType<NoteLimit>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();

            noteLimit.OnHitNote();
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();

            noteLimit.OnHitNote();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();

            noteLimit.OnHitNote();
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();

            noteLimit.OnHitNote();
        }
    }


}
