using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool checkpointActive;
    public SpriteRenderer spriteRenderer;
    public Sprite activeSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkpointActive = true;
            spriteRenderer.sprite = activeSprite;
        }
    }
}
