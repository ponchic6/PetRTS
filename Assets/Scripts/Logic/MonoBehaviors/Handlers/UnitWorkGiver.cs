using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UnitWorkGiver : MonoBehaviour, IUnitWorkerGiver
{
    [SerializeField] private UnitStaticData _unitConfig;
    [SerializeField] private SelectStatusChanger _selectStatusChanger;
    [SerializeField] private UnitBuildingHandler _unitBuildingHandler;
    [SerializeField] private UnitResourceHandler _unitResourceHandler;
    private IInputService _inputService;
    private JobProgressData _currentJobProgressData;
    private ResourceCollector _currentResourceCollector;

    private void Awake()
    {
        _unitBuildingHandler.OnStopWorking += RemoveUnitFromList;
        _unitResourceHandler.OnStopWorking += RemoveUnitFromList;
    }


    [Inject]
    public void Constructor(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += TrySetWorkPoint;
    }

    public JobProgressData GetCurrentJopProgressData()
    {
        if (HasConditionForWork())
        {
            return _currentJobProgressData;
        }

        return null;
    }

    public ResourceCollector GetCurrentResourcesCollector()
    {
        if (HasConditionForResourceCollecting())
        {
            return _currentResourceCollector;            
        }

        return null;
    }

    private void TrySetWorkPoint()
    {
        if (_selectStatusChanger.IsSelect())
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
            Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity);

            TrySetJobProgressData(raycastHit);
            TrySetResourceCollector(raycastHit);
        }
    }

    private bool HasConditionForWork()
    {
        return _currentJobProgressData != null && 
               Vector3.Distance(transform.position, _currentJobProgressData.GetTransform().position) <= _unitConfig.DistanceForWork &&
               _currentJobProgressData.HasObjectJob;
    }

    private bool HasConditionForResourceCollecting()
    {
        return _currentResourceCollector != null &&
               Vector3.Distance(transform.position, _currentResourceCollector.GetTransform().position) <=
               _unitConfig.DistanceForWork;
    }

    private void TrySetJobProgressData(RaycastHit raycastHit)
    {
        if (raycastHit.collider.gameObject.TryGetComponent(out JobProgressData workableObject))
        {
            _currentJobProgressData = workableObject;
        }

        else
        {
            _currentJobProgressData = null;
        }
    }

    private void TrySetResourceCollector(RaycastHit raycastHit)
    {
        if (raycastHit.collider.gameObject.TryGetComponent(out ResourceCollector resourceCollector))
        {
            _currentResourceCollector = resourceCollector;
        }

        else
        {
            _currentResourceCollector = null;
        }
    }

    private void RemoveUnitFromList()
    {
        if (_currentJobProgressData != null)
        {
            _currentJobProgressData.gameObject.GetComponent<IWorkingWorkersList>().TryRemoveUnit(gameObject.GetComponent<IMoveble>());
        }
    }
}