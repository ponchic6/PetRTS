using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

public class UnitResourceHandler : UnitWorkHandler
{
    private float _currentResourceCount;
    private float _currentCooldown;
    private ResourceCollector _resourceCollector;

    protected override void Awake()
    {
        base.Awake();
        _unitWorkerGiver.OnAvailabilidtyToResourceCollector += SetResourceCollector;
    }

    private void Update()
    {
        TryWork();
        PutResourcesInStorage();
    }

    protected override void TryWork()
    {
        if (_jobProgressData != null && _jobProgressData is ResourceJobProgressData)
        {
            if (_currentResourceCount < _unitConfig.MaxResourceOnUnit)
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

            if (_currentResourceCount + _unitConfig.Efficiency >= _unitConfig.MaxResourceOnUnit)
            {
                _jobProgressData.UpdateProgress(_unitConfig.MaxResourceOnUnit - _currentResourceCount);
                _currentResourceCount = _unitConfig.MaxResourceOnUnit;
            }

            else
            {
                _jobProgressData.UpdateProgress(_unitConfig.Efficiency);
                _currentResourceCount += _unitConfig.Efficiency;
            }
            
            _currentCooldown = _unitConfig.Cooldown;
        }

        else
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    private void PutResourcesInStorage()
    {
        if (_resourceCollector != null && _currentResourceCount != 0)
        {
            _resourceCollector.AddResource(_currentResourceCount);
            _currentResourceCount = 0;
        }
    }

    private void SetResourceCollector(ResourceCollector resourceCollector)
    {
        _resourceCollector = resourceCollector;
    }
}