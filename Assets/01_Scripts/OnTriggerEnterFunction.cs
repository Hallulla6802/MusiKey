using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Sprite"))
        {
            Destroy(other.gameObject);
        }
    }
}
