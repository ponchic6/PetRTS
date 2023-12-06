using System;
using UnityEngine;

public class UnitBuildingHandler : UnitWorkHandler
{
    private float _currentCooldown;

    private void Update()
    {
        TryWork();
    }

    protected override void TryWork()
    {
        if (_jobProgressData != null && _jobProgressData is BuildingJobProgressData)
        {
            if (_jobProgressData.HasObjectJob)
            {
                _unitWorkerGiver.IsWorking = true;

                UpdateProgress();
            }

            else
            {
                _unitWorkerGiver.IsWorking = false;
            }
        }

        if (_jobProgressData == null)
        {
            _unitWorkerGiver.IsWorking = false;
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