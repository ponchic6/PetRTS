using System;
using UnityEngine;

public class UnitBuildingHandler : UnitWorkHandler
{
    private float _currentCooldown;

    private void Update()
    {   
        SetJobProgressData();
        TryWork();
    }

    protected override void TryWork()
    {
        if (_jobProgressData != null && _jobProgressData is BuildingJobProgressData)
        {
            if (_jobProgressData.HasObjectJob)
            {   
                InvokeOnStartWorking();
                UpdateProgress();
            }

            else
            {
                InvokeOnStopWorking();
            }
        }

        if (_jobProgressData == null)
        {
            InvokeOnStopWorking();
        }
    }

    private void UpdateProgress()
    {
        if (_currentCooldown <= 0)
        {
            _jobProgressData.UpdateProgress(_unitConfig.Efficiency);
            _currentCooldown = _unitConfig.Cooldown;
        }

        else
        {
            _currentCooldown -= Time.deltaTime;
        }
    }
    
    private void SetJobProgressData()
    {
        _jobProgressData = _unitWorkerGiver.GetCurrentJopProgressData();
    }
}