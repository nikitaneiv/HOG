using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _text;

    private int _count;
    public int Count => _count;

    public void SetSprite(Sprite sprite)
    {
        if (sprite == null)
        
            throw new ArgumentNullException(nameof(sprite), "Sprite is null"); 
        
        _image.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _count = count;
        _text.text = count.ToString();
    }

    public void Decrease()
    {
        _count--;
        SetCount(_count);
    }
}
