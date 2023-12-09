using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class JobProgressData : MonoBehaviour
{   
    public event Action OnFinishedWorking;

    [SerializeField] protected float _maxProgress;
    protected float _currentProgress;
    private IWorkingWorkersList _workingWorkersList;
    
    public bool HasObjectJob { get; set; } = true;

    protected virtual void Awake()
    {
        _workingWorkersList = GetComponent<IWorkingWorkersList>();
    }

    protected void InvokeOnFinishedWorking()
    {
        OnFinishedWorking?.Invoke();
    }

    public abstract void UpdateProgress(float delta);

    public float GetCurrentProgress()
    {
        return _currentProgress;
    }

    public float GetMaxProgress()
    {
        return _maxProgress;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public IWorkingWorkersList GetWorkingWorkersList()
    {
        return _workingWorkersList;
    }
}