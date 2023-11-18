using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitMover : MonoBehaviour, IMoveble
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private ViewSelectStatusChanger _selectStatusChanger;
    private IDestinationUnitSetter _destinationUnitSetter;

    [Inject]
    public void Constructor(IDestinationUnitSetter destinationUnitSetter)
    {
        _destinationUnitSetter = destinationUnitSetter;
        _destinationUnitSetter.OnSetDestination += MoveToDestination;
    }

    public void MoveToDestination(Vector3 destination)
    {
        if (_selectStatusChanger.IsSelect())
        {
            _navMeshAgent.SetDestination(destination);
        }
    }
}