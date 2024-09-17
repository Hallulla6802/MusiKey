using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnersScript : MonoBehaviour
{
    public GameObject spritePrefab;        // The sprite to spawn
    public Transform[] spawners;           // Array of spawner positions (empty GameObjects)
    public KeyCode[] spawnKeys;            // Array of keys to trigger each spawner
    public float speed = 5f;               // Speed of movement
    public string spriteTag = "Sprite";    // Tag for identifying sprites
    

    private void Update()
    {
        
        for (int i = 0; i < spawners.Length; i++)
        {
            if (Input.GetKeyDown(spawnKeys[i]))
            {
                SpawnSpriteAtSpawner(i);
            }
        }

        
        MoveSprites();
    }

    
    void SpawnSpriteAtSpawner(int index)
    {
        GameObject newSprite = Instantiate(spritePrefab, spawners[index].position, Quaternion.identity);
        newSprite.tag = spriteTag; 
        
    }

    
    void MoveSprites()
    {
        GameObject[] sprites = GameObject.FindGameObjectsWithTag(spriteTag);
        foreach (GameObject sprite in sprites)
        {
            sprite.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    
    
}
