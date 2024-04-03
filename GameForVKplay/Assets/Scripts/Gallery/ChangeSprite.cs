using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Image")]
    [SerializeField] Image image;

    [Header("Sprites")]
    [SerializeField] Sprite[] VerSprites;
    [SerializeField] Sprite[] HorSprites;

    public void ChangeSpriteTop()
    {
        int a;
        a = HorSprites.Length + (HorSprites.Length - 1);
    }

    public void ChangeSpriteDown()
    {

    }

    public void ChangeSpriteLeft() 
    {

    }

    public void ChangeSpriteRight() 
    { 
    
    }

}
