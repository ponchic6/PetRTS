using UnityEngine;

public abstract class UnitWorkHandler : MonoBehaviour
{
    [SerializeField] protected UnitConfig _unitConfig;
    protected IUnitWorkerGiver _unitWorkerGiver;
    protected JobProgressData _jobProgressData;

    protected virtual void Awake()
    {
        _unitWorkerGiver = GetComponent<IUnitWorkerGiver>();
    }

    protected abstract void TryWork();
}