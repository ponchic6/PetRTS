using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitMover : MonoBehaviour, IMoveble
{
    private NavMeshAgent _navMeshAgent;
    private ViewSelectStatusChanger _selectStatusChanger;
    private IDestinationUnitSetter _destinationUnitSetter;

    [Inject]
    public void Constructor(IDestinationUnitSetter destinationUnitSetter)
    {
        _destinationUnitSetter = destinationUnitSetter;
        _destinationUnitSetter.OnSetDestination += MoveToDestination;
    }

    private void Awake()
    {
        _selectStatusChanger = GetComponent<ViewSelectStatusChanger>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    public void MoveToDestination(Vector3 destination)
    {
        if (_selectStatusChanger.IsSelect())
        {
            _navMeshAgent.SetDestination(destination);
        }
    }
}