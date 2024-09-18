using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnersScript : MonoBehaviour
{
    public GameObject spriteZ;   // the sprite Z to spawn 
    public GameObject spriteX;   // The sprite X to spawn
    public Transform[] spawners;           // Array of spawner positions (empty GameObjects)
    public KeyCode[] spawnKeys;            // Array of keys to trigger each spawner
    public float speed = 5f;               // Speed of movement
    public string spritexTag = "SpriteX";
    public string spritezTag = "SpriteZ"; 
    public int randomNumber;
    

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
        randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            GameObject newSprite = Instantiate(spriteX, spawners[index].position, Quaternion.identity);
            newSprite.tag = spritexTag;
        }

        if (randomNumber == 1)
        {
            GameObject newSprite = Instantiate(spriteZ, spawners[index].position, Quaternion.identity);
            newSprite.tag = spritezTag;
        }

    }

    
    void MoveSprites()
    {
        
        GameObject[] spritexs = GameObject.FindGameObjectsWithTag(spritexTag);
        foreach (GameObject sprite in spritexs)
        {
            sprite.transform.Translate(Vector3.back * speed * Time.deltaTime);  
        }

        
        GameObject[] spritezs = GameObject.FindGameObjectsWithTag(spritezTag);
        foreach (GameObject sprite in spritezs)
        {
            sprite.transform.Translate(Vector3.back * speed * Time.deltaTime);  
        }
    }



}
