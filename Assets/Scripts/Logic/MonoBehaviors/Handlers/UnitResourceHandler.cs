using UnityEngine;

public class UnitResourceHandler : UnitWorkHandler
{
    private float _currentResourceCount;
    private float _currentCooldown;
    
    protected override void TryWork()
    {
        if (_progressData != null && _progressData is ResourceProgressData)
        {
            if (_currentResourceCount <= _unitConfig.MaxResourceOnUnit)
            {
                _unitWorkerGiver.IsWorking = true;

                if (_currentCooldown <= 0)
                {
                    _currentResourceCount += _unitConfig.Efficiency;
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
        
        else
        {
            _unitWorkerGiver.IsWorking = false;
        }
    }
}