using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UnitWorkGiver : MonoBehaviour, IUnitWorkerGiver
{
    [SerializeField] private UnitStaticData _unitConfig;
    [SerializeField] private ViewSelectStatusChanger _viewSelectStatusChanger;
    private IMoveble _unitMover;
    private IInputService _inputService;
    private JobProgressData _currentJobProgressData;
    private ResourceCollector _currentResourceCollector;

    public bool IsWorking { get; set; }

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
    }

    [Inject]
    public void Constructor(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += TrySendToWorkPoint;
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
    
    private void TrySendToWorkPoint()
    {
        if (_viewSelectStatusChanger.IsSelect())
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
            Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity);

            TrySetJobProgressData(raycastHit);
            TrySetDestinationToJob();

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

    private void TrySetDestinationToJob()
    {
        if (_currentJobProgressData != null)
        {
            Vector3 directionToWorkPoint = (_currentJobProgressData.GetTransform().position -
                                            transform.position).normalized;
            Vector3 destination = _currentJobProgressData.GetTransform().position -
                                  directionToWorkPoint * (_unitConfig.DistanceForWork - 0.1f);

            _unitMover.MoveToDestination(destination);
        }
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
}