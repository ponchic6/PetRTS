using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitMover : MonoBehaviour, IMoveble
{
    private NavMeshAgent _navMeshAgent;
    private ViewSelectStatusChanger _selectStatusChanger;

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

    public Vector3 GetCurrentSpeed()
    {
        return _navMeshAgent.velocity;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}