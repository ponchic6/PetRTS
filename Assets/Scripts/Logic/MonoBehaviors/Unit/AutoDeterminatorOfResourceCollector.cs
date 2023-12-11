using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeterminatorOfResourceCollector : MonoBehaviour
{
    [SerializeField] private UnitStaticData _unitStaticData;
    [SerializeField] private UnitResourceHandler _unitResourceHandler;
    private IMoveble _unitMover;
    private IUnitWorkerGiver _unitWorkerGiver;

    private JobProgressData _currentJobProgressData;
    private ResourceCollector _currentResourceCollector;
    
    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
        
        _unitWorkerGiver = GetComponent<IUnitWorkerGiver>();
        _unitWorkerGiver.OnJobProgressClick += StartToTransportResourcesToCollector;
    }

    private void StartToTransportResourcesToCollector(JobProgressData jobProgressData)
    {
        if (jobProgressData != null && jobProgressData is ResourceJobProgressData)
        {
            _currentJobProgressData = jobProgressData;
            FindResourceCollector();
            StartCoroutine(StartToTransportCoroutine());
        }

        else
        {
            StopAllCoroutines();
        }
    }

    private void FindResourceCollector()
    {
        _currentResourceCollector = FindObjectOfType<ResourceCollector>();
    }

    private IEnumerator StartToTransportCoroutine()
    {
        while (true)
        {
            _currentJobProgressData.WorkingWorkersListService.SetDestination(_unitMover);
            _unitResourceHandler.SetJobProgress(_currentJobProgressData);
            
            while (_unitResourceHandler.CurrentResourceCount < _unitStaticData.MaxResourceOnUnit)
            {
                yield return null;
            }
            
            _unitMover.MoveToDestination(_currentResourceCollector.transform.position);
            _unitResourceHandler.SetResourceCollector(_currentResourceCollector);
            _unitResourceHandler.SetJobProgress(_currentResourceCollector.transform.GetComponent<JobProgressData>());
            
            while (_unitResourceHandler.CurrentResourceCount != 0f)
            {
                yield return null;
            }
        }
    } 
}
