using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private InkManager _inkManager;
    public SpriteRenderer Normal;
    public Sprite Happy;
    public Sprite Worried;


    private Story _story;

    void Start()
    {
        _inkManager = FindObjectOfType<InkManager>();
        Normal = gameObject.GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        if (Normal.CompareTag("Norm"))
        {
            ChangeSprite(Happy);
        }
        else if(Normal.CompareTag("Wor"))
        {
            ChangeSprite(Worried);

        }
        else
        {
            Debug.Log("No Tag found");
        }
       

    }
    void ChangeSprite(Sprite newSprite)
    {
        Normal.sprite = newSprite;
        Debug.Log("Sprite Changed");
    }
}
