using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class JobProgressData : MonoBehaviour
{   
    public event Action OnFinishedWorking;

    [SerializeField] protected float _maxProgress;
    protected float _currentProgress;
    private IWorkingWorkersListService _workingWorkersListService;
    
    public bool HasObjectJob { get; set; } = true;
    public float CurrentProgress => _currentProgress;
    public float MaxProgress => _maxProgress;
    public Vector3 Position => transform.position;
    public IWorkingWorkersListService WorkingWorkersListService => _workingWorkersListService;

    protected virtual void Awake()
    {
        _workingWorkersListService = GetComponent<IWorkingWorkersListService>();
    }

    public abstract void UpdateProgress(float delta);

    protected void InvokeOnFinishedWorking()
    {
        OnFinishedWorking?.Invoke();
    }
}