using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeSprite(newSprite);
        }
    }
    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
        Debug.Log("Sprite Changed");
    }
}
