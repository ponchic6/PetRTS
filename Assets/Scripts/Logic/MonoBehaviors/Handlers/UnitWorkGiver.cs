using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UnitWorkGiver : MonoBehaviour, IWorkHandler
{
    [SerializeField] private float _distanceForWork;
    [SerializeField] private ViewSelectStatusChanger _viewSelectStatusChanger;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _efficiency;
    private float _currentCooldown;
    private IMoveble _unitMover;
    private IInputService _inputService;
    private ProgressData _currentProgressData;
    
    public bool IsWorking { get; private set; }

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
    }

    private void Update()
    {
        TryWork();
        ReduceCooldown();
    }

    [Inject]
    public void Constructor(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += TrySendToWorkPoint;
    }

    public ProgressData GetProgressData()
    {
        return _currentProgressData;
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

                Vector3 directionToWorkPoint = (_currentProgressData.GetTransform().position -
                                                transform.position).normalized;
                Vector3 destination = _currentProgressData.GetTransform().position - 
                                      directionToWorkPoint * (_distanceForWork - 0.1f); 
                
                _unitMover.MoveToDestination(destination);
            }

            else
            {
                _currentProgressData = null;
            }
        }
    }

    private void TryWork()
    {
        if (CanUpdateBuildingProgress())
        {
            IsWorking = true;
            
            if (_currentCooldown <= 0)
            {
                _currentProgressData.UpdateProgress(_efficiency);
                _currentCooldown = _cooldown;
            }
        }

        else
        {
            IsWorking = false;
        }
    }

    private void ReduceCooldown()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    private bool CanUpdateBuildingProgress()
    {
        return _currentProgressData != null && 
               Vector3.Distance(transform.position, _currentProgressData.GetTransform().position) <= _distanceForWork &&
               _currentProgressData.HasObjectJob;
    }
}