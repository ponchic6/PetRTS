using System;
using UnityEngine;

public abstract class UnitWorkHandler : MonoBehaviour
{
    public event Action OnStartWorking; 
    public event Action OnStopWorking;

    [SerializeField] protected UnitStaticData _unitConfig;
    protected IUnitWorkerGiver _unitWorkerGiver;
    protected JobProgressData _jobProgressData;

    protected virtual void Awake()
    {
        _unitWorkerGiver = GetComponent<IUnitWorkerGiver>();
    }

    protected abstract void TryWork();

    protected void InvokeOnStartWorking()
    {
        OnStartWorking?.Invoke();
    }

    protected void InvokeOnStopWorking()
    {
        OnStopWorking?.Invoke();
    }
}