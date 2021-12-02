using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private InkManager _inkManager;
    public SpriteRenderer Sprite;
    public Sprite newSprite;
    private Story _story;

    void Start()
    {
        _inkManager = FindObjectOfType<InkManager>();
        Sprite = gameObject.GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        if (Sprite.CompareTag("Amina"))
        {
            ChangeSprite(newSprite);
        }
        else
        {
            Debug.Log("No Tag found");
        }
       

    }
    void ChangeSprite(Sprite newSprite)
    {
        Sprite.sprite = newSprite;
        Debug.Log("Sprite Changed");
    }
}
