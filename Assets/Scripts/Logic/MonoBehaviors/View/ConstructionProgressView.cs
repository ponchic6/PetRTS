using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionProgressView : MonoBehaviour, IConstructionProgressView
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Image _healthBar;
    private float _constructionProgress;

    public bool IsBuilded { get; private set; }

    private void Awake()
    {
        _constructionProgress = 0f;
        _healthBar.fillAmount = _constructionProgress;
    }

    private void Update()
    {   
        ShowConstructionProgress();
    }

    public void IncreaseBuildingProgress(float delta)
    {
        if (_constructionProgress + delta < _maxHealth)
        {
            _constructionProgress += delta;
        }
        
        else 
        {
            _constructionProgress = _maxHealth;
            IsBuilded = true;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    private void ShowConstructionProgress()
    {
        _healthBar.fillAmount = _constructionProgress / _maxHealth;
    }
}