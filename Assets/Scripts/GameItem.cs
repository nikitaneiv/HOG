using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class GameItem : MonoBehaviour
{
    [SerializeField] private string _name;
    private SpriteRenderer _spriteRenderer;

    public string Name => _name;
    public Sprite Sprite => _spriteRenderer.sprite;
    public event Action<string> Onfind;
    private FindComponents _findComponents;

    private void Awake()
    {
        _findComponents = GetComponent<FindComponents>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseUpAsButton()
    {
        OnFindMethod();
    }

    public void OnFindMethod()
    {
        _findComponents.DoEffects(() =>
        {
            Onfind?.Invoke(_name);
            Onfind = null;
        });
    }
}
