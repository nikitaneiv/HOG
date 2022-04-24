using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class DoEffect : FindComponents
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private float _Duration;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void DoEffects(Action callback)
    {
        _spriteRenderer.DOFade(0f, _Duration);
        transform.DOScale(transform.localScale * _scaleMultiplier, _Duration).OnComplete(() =>
         {
             gameObject.SetActive(false);
             callback?.Invoke();
         });
    }
}
