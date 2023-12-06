using UnityEngine;

public abstract class UnitWorkHandler : MonoBehaviour
{
    [SerializeField] protected UnitConfig _unitConfig;
    protected IUnitWorkerGiver _unitWorkerGiver;
    protected JobProgressData _jobProgressData;

    protected virtual void Awake()
    {
        _unitWorkerGiver = GetComponent<IUnitWorkerGiver>();
        _unitWorkerGiver.OnAvailabilityToProgressData += SetCurrentToProgressData;
    }

    protected abstract void TryWork();

    private void SetCurrentToProgressData(JobProgressData jobProgressData)
    {
        _jobProgressData = jobProgressData;
    }
}