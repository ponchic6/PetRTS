using System;
using UnityEngine;

public class UnitBuildingHandler : UnitWorkHandler
{
    private void Update()
    {
        TryWork();
    }

    protected override void TryWork()
    {
        if (IsDistanceEnoughToWork() && _jobProgressData is BuildingJobProgressData)
        {
            if (IsWorking == false)
            {
                InvokeOnStartWorking();
                IsWorking = true;
            }

            if (_jobProgressData.HasObjectJob)
            {
                UpdateProgress();
            }

            if (!_jobProgressData.HasObjectJob && IsWorking)
            {
                IsWorking = false;
                _jobProgressData.GetWorkingWorkersList().TryRemoveUnit(gameObject.GetComponent<IMoveble>());
                InvokeOnStopWorking();                
            }
        }

        if (_jobProgressData == null && IsWorking)
        {
            IsWorking = false;
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
}