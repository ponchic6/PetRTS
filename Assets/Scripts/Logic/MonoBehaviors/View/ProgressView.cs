using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ProgressView : MonoBehaviour
{
    [SerializeField] private JobProgressData _jobProgressData;
    [SerializeField] private Image _progressBar;
    private void Update()
    {   
        ShowConstructionProgress();
    }
    
    private void ShowConstructionProgress()
    {
        _progressBar.fillAmount = _jobProgressData.CurrentProgress / _jobProgressData.MaxProgress;
    }
}