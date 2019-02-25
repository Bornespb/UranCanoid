using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //Config
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
   // [SerializeField] int maxHits;
    [SerializeField] Sprite[] spritesRange;
    //Cached refs
    Level level;
    GameSession gameStatus;

    //States
    [SerializeField] int timesHit; //todo serialized only for debug

    //Methods
    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = spritesRange.Length+1;
            if (timesHit == maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (spritesRange[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = spritesRange[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array in "+name);
        }
    }

    private void DestroyBlock()
    {
            PlayBlockDestroyVFX();
            level.BlockDestroyed();
            Destroy(this.gameObject);
            TriggerSparklesVFX();
    }

    private void PlayBlockDestroyVFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 2);
    }
}
