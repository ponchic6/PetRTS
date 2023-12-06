using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UnitWorkGiver : MonoBehaviour, IUnitWorkerGiver
{
    public event Action<ProgressData> OnAvailabilityProgressData;

    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private ViewSelectStatusChanger _viewSelectStatusChanger;
    private IMoveble _unitMover;
    private IInputService _inputService;
    private ProgressData _currentProgressData;

    public bool IsWorking { get; set; }

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
    }

    private void Update()
    {
        TryWork();
    }

    [Inject]
    public void Constructor(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += TrySendToWorkPoint;
    }

    private void TrySendToWorkPoint()
    {
        if (_viewSelectStatusChanger.IsSelect())
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
            
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity) &&
                raycastHit.collider.gameObject.TryGetComponent(out ProgressData workableObject))
            {
                _currentProgressData = workableObject;

                SetWorkDestination();
            }

            else
            {
                _currentProgressData = null;
            }
        }
    }

    private void TryWork()
    {
        if (CanUpdateWorkProgress())
        {
            OnAvailabilityProgressData?.Invoke(_currentProgressData);
        }

        else
        {
            OnAvailabilityProgressData?.Invoke(null);
        }
    }
    
    private bool CanUpdateWorkProgress()
    {
        return _currentProgressData != null && 
               Vector3.Distance(transform.position, _currentProgressData.GetTransform().position) <= _unitConfig.DistanceForWork &&
               _currentProgressData.HasObjectJob;
    }

    private void SetWorkDestination()
    {
        Vector3 directionToWorkPoint = (_currentProgressData.GetTransform().position -
                                        transform.position).normalized;
        Vector3 destination = _currentProgressData.GetTransform().position -
                              directionToWorkPoint * (_unitConfig.DistanceForWork - 0.1f);

        _unitMover.MoveToDestination(destination);
    }
}