using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksController : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public List<Sprite> hitSprites; // List of sprites for each hit state

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    public void BreakBrick()
    {
        hitsToBreak--;
        UpdateSprite();

        // Add any additional logic when the brick breaks
    }

    private void UpdateSprite()
    {
        if (hitsToBreak > 0 && hitsToBreak <= hitSprites.Count)
        {
            spriteRenderer.sprite = hitSprites[hitsToBreak - 1];
        }
    }
}
