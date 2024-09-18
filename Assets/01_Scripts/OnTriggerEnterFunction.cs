using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnTriggerEnterFunction : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("SpriteX") && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SpriteZ") && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(other.gameObject);
        }
    }

   
}
