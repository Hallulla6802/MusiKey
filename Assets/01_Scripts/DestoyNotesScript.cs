using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyNotesScript : MonoBehaviour
{
    public AudioSource feedbackSound;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(other.gameObject);
            feedbackSound.Play();
        }
    }


}
