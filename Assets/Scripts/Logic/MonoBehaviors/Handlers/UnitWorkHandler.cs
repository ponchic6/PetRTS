using System;
using UnityEngine;

public abstract class UnitWorkHandler : MonoBehaviour
{
    public event Action OnStartWorking; 
    public event Action OnStopWorking;

    [SerializeField] protected UnitStaticData _unitConfig;
    protected IUnitWorkerGiver _unitWorkerGiver;
    protected JobProgressData _jobProgressData;
    protected float _currentCooldown;
    
    protected bool IsWorking { get; set; }

    protected virtual void Awake()
    {
        _unitWorkerGiver = GetComponent<IUnitWorkerGiver>();
        _unitWorkerGiver.OnJobProgressClick += SetJobProgress;
    }

    protected abstract void TryWork();
    
    protected bool IsDistanceEnoughToWork()
    {
        return _jobProgressData != null &&
               Vector3.Distance(transform.position, _jobProgressData.GetPosition()) <=
               _unitConfig.DistanceForWork;
    }

    protected void InvokeOnStartWorking()
    {
        OnStartWorking?.Invoke();
    }

    protected void InvokeOnStopWorking()
    {
        OnStopWorking?.Invoke();
    }

    private void SetJobProgress(JobProgressData jobProgressData)
    {
        if (_jobProgressData != null && jobProgressData == null)
        {
            _jobProgressData.GetWorkingWorkersList().TryRemoveUnit(gameObject.GetComponent<IMoveble>());
        }
        
        _jobProgressData = jobProgressData;
    }
}