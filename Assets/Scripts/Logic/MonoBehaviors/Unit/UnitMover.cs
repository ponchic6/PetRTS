using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Zenject;
using Object = System.Object;

public class UnitMover : MonoBehaviour, IMoveble
{
    [SerializeField] private UnitStaticData _unitStaticData;
    private NavMeshAgent _navMeshAgent;
    private SelectStatusChanger _selectStatusChanger;

    public Vector3 CurrentSpeed => _navMeshAgent.velocity; 
    public Transform Transform => transform;
    public UnitStaticData UnitStaticData => _unitStaticData;

    private void Awake()
    {
        _selectStatusChanger = GetComponent<SelectStatusChanger>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDestination(Vector3 destination, GameObject rotateToObject = null)
    {   
        StopAllCoroutines();
        StartCoroutine(MoveCoroutine(destination, rotateToObject));
    }

    private IEnumerator MoveCoroutine(Vector3 destination, GameObject rotateToObject = null)
    {
        if (_selectStatusChanger.IsSelect())
        {
            float elapsedTime = 0;
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
            
            while (elapsedTime < _unitStaticData.RotateDuration)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / _unitStaticData.RotateDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            if (rotateToObject == null)
            {
                _navMeshAgent.SetDestination(destination);
            }

            else
            {
                while (transform.position != destination)
                {
                    _navMeshAgent.SetDestination(destination);
                    yield return null;
                }
            
                elapsedTime = 0;
                targetRotation = Quaternion.LookRotation(rotateToObject.transform.position - transform.position);
        
                while (elapsedTime < _unitStaticData.RotateDuration)
                {
                    transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / _unitStaticData.RotateDuration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}