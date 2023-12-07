using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitMover : MonoBehaviour, IMoveble
{
    [SerializeField] private UnitStaticData _unitConfig;
    private NavMeshAgent _navMeshAgent;
    private ViewSelectStatusChanger _selectStatusChanger;

    private void Awake()
    {
        _selectStatusChanger = GetComponent<ViewSelectStatusChanger>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDestination(Vector3 destination)
    {
        StartCoroutine(MoveCoroutine(destination));
    }

    public Vector3 GetCurrentSpeed()
    {
        return _navMeshAgent.velocity;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    private IEnumerator MoveCoroutine(Vector3 destination)
    {
        if (_selectStatusChanger.IsSelect())
        {
            float elapsedTime = 0;
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
            
            while (elapsedTime < _unitConfig.RotateDuration)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / _unitConfig.RotateDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            _navMeshAgent.SetDestination(destination);
        }
    }
}