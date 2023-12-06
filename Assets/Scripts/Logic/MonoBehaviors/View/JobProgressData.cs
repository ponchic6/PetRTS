using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class JobProgressData : MonoBehaviour
{   
    public event Action OnFinishedWorking;

    [SerializeField] protected float _maxProgress;
    protected float _currentProgress;

    public bool HasObjectJob { get; set; } = true;
    
    public abstract void UpdateProgress(float delta);

    public float GetCurrentProgress()
    {
        return _currentProgress;
    }

    public float GetMaxProgress()
    {
        return _maxProgress;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    protected void InvokeOnFinishedWorking()
    {
        OnFinishedWorking?.Invoke();
    }
}