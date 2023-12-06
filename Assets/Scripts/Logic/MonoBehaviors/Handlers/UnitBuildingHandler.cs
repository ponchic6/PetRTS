using UnityEngine;

public class UnitBuildingHandler : UnitWorkHandler
{
    private float _currentCooldown;
    
    protected override void TryWork()
    {
        if (_progressData != null && _progressData is BuildingProgressData)
        {
            if (_progressData.HasObjectJob)
            {
                _unitWorkerGiver.IsWorking = true;

                if (_currentCooldown <= 0)
                {
                    _progressData.UpdateProgress(_unitConfig.Efficiency);
                    _currentCooldown = _unitConfig.Cooldown;
                }

                else
                {
                    _currentCooldown -= Time.deltaTime;
                }
            }

            else
            {
                _unitWorkerGiver.IsWorking = false;
            }
        }
   
    }
}