using System.Collections;
using Logic.MonoBehaviors.Handlers;
using Logic.MonoBehaviors.Unit;
using Logic.MonoBehaviors.View;
using UnityEngine;

namespace Logic.MonoBehaviors.Mediators
{
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
                
                if (_currentResourceCollector == null)
                {
                    return;    
                }
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
                _unitResourceHandler.SetResourceCollector(_currentResourceCollector);

                while (_unitResourceHandler.CurrentResourceCount < _unitStaticData.MaxResourceOnUnit)
                {
                    yield return null;
                }

                _unitResourceHandler.SetJobProgress(_currentResourceCollector.transform
                    .GetComponent<JobProgressData>());
                _unitResourceHandler.SetResourceCollector(_currentResourceCollector);

                while (_unitResourceHandler.CurrentResourceCount != 0f)
                {
                    yield return null;
                }
            }
        }
    }

}