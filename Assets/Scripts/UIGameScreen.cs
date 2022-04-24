using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameScreen : MonoBehaviour
{
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private GameObject _uiItemPrefab;

    private Dictionary<string, UIGameItem> _uiItems = new Dictionary<string, UIGameItem>();

    public void Initialize(Dictionary<string,GameItemData> itemsData)
    {
        foreach (var key in _uiItems.Keys)
        {
            Destroy(_uiItems[key].gameObject);
        }
        _uiItems.Clear();
        GenerateUIItem(itemsData);
    }

    private void GenerateUIItem(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            GameObject uiGameItem = Instantiate(_uiItemPrefab, _contentTransform);
            UIGameItem gameItemComponent = uiGameItem.GetComponent<UIGameItem>();

            gameItemComponent.SetSprite(itemsData[key].Sprite);
            gameItemComponent.SetCount(itemsData[key].Count);

            _uiItems.Add(key, gameItemComponent);
        }
    }

    public void OnItemFind(string name)
    {
        _uiItems[name].Decrease();
        if (_uiItems[name].Count == 0)
        {
            Destroy(_uiItems[name].gameObject);
            _uiItems.Remove(name);
        }
    }
}
