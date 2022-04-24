using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;


public class Level : MonoBehaviour
{
    private List<GameItem> _items = new List<GameItem>();
    private int _itemCount;

    public event Action OnComplete;
    public event Action<string> OnItemListChange;

    public void Initialize()
    {
        GameItem[] gameItems = GetComponentsInChildren<GameItem>();
        _items.AddRange(gameItems);
        _itemCount = _items.Count;

        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].Onfind += OnItemFinded;
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> dictionary = new Dictionary<string, GameItemData>();
        for (int i = 0; i < _items.Count; i++)
        {
            if (dictionary.ContainsKey(_items[i].Name) == true)
            {
                dictionary[_items[i].Name].IncreaseCount();
            }
            else
            {
                dictionary.Add(_items[i].Name, new GameItemData(_items[i].Sprite));
            }
        }
        return dictionary;
    }

    private void OnItemFinded(string name)
    {
        _itemCount--;
        OnItemListChange?.Invoke(name);
        if (_itemCount == 0)
        {
            OnComplete?.Invoke();
        }
    }
}
