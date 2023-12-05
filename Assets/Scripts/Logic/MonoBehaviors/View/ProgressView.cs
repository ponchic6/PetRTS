using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressView : MonoBehaviour
{
    [SerializeField] private ProgressData _progressData;
    [SerializeField] private Image _progressBar;
    private void Update()
    {   
        ShowConstructionProgress();
    }
    
    private void ShowConstructionProgress()
    {
        _progressBar.fillAmount = _progressData.GetCurrentProgress() / _progressData.GetMaxProgress();
    }
}