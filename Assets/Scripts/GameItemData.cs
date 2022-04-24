using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemData 
{
    private Sprite _sprite;
    private int _count;

    public Sprite Sprite => _sprite;
    public int Count => _count;

    public GameItemData(Sprite sprite)
    {
        _sprite = sprite;
        _count = 1;
    }

    public void IncreaseCount() => _count++;
    public void DecreaseCount() => _count--;
}
