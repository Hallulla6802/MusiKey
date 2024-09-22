using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyNotesScript : MonoBehaviour
{
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(other.gameObject);
        }
    }


}
