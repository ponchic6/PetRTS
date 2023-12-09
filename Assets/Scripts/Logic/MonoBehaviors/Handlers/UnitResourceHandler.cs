using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

public class UnitResourceHandler : UnitWorkHandler
{
    private float _currentResourceCount;
    private ResourceCollector _resourceCollector;

    protected override void Awake()
    {
        base.Awake();
        _unitWorkerGiver.OnResourceCollectorClick += SetResourceCollector;
    }

    private void Update()
    {
        TryWork();
        TryPutResourcesInCollector();
    }

    protected override void TryWork()
    {
        if (IsDistanceEnoughToWork() && _jobProgressData is ResourceJobProgressData)
        {
            if (_currentResourceCount < _unitConfig.MaxResourceOnUnit)
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

            else
            {   
                if (IsWorking)
                {
                    IsWorking = false;
                    _jobProgressData.GetWorkingWorkersList().TryRemoveUnit(gameObject.GetComponent<IMoveble>());
                    InvokeOnStopWorking();
                }
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

    private void SetResourceCollector(ResourceCollector resourceCollector)
    {
        _resourceCollector = resourceCollector;
    }

    private void TryPutResourcesInCollector()
    {
        if (_resourceCollector != null && _currentResourceCount != 0 && HasConditionForResourceCollecting())
        {
            _resourceCollector.AddResource(_currentResourceCount);
            _currentResourceCount = 0;
        }
    }
    
    private bool HasConditionForResourceCollecting()
    {
        return _resourceCollector != null &&
               Vector3.Distance(transform.position, _resourceCollector.GetTransform().position) <=
               _unitConfig.DistanceForWork;
    }
}