using UnityEngine;

public abstract class UnitWorkHandler : MonoBehaviour
{
    [SerializeField] protected UnitConfig _unitConfig;
    protected IUnitWorkerGiver _unitWorkerGiver;
    protected ProgressData _progressData;

    private void Awake()
    {
        _unitWorkerGiver = GetComponent<IUnitWorkerGiver>();
        _unitWorkerGiver.OnAvailabilityProgressData += SetCurrentProgressData;
    }

    protected abstract void TryWork();

    private void Update()
    {
        TryWork();
    }

    private void SetCurrentProgressData(ProgressData progressData)
    {
        _progressData = progressData;
    } 
    
}