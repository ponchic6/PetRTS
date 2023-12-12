using Logic.MonoBehaviors.Handlers;
using Logic.MonoBehaviors.View;
using UnityEngine;

namespace Logic.MonoBehaviors.Unit
{
    public class UnitResourceHandler : UnitWorkHandler
    {
        private float _currentResourceCount;
        private ResourceCollector _resourceCollector;

        public float CurrentResourceCount => _currentResourceCount;

        protected override void Awake()
        {
            base.Awake();
            _unitWorkerGiver.OnResourceCollectorClick += SetResourceCollector;
        }

        private void Update()
        {
            TryWork();
            TryAutoPutResourcesInCollector();
        }

        public void SetResourceCollector(ResourceCollector resourceCollector)
        {
            _resourceCollector = resourceCollector;
        }

        protected override void TryWork()
        {
            if (IsDistanceEnoughToWork() && _jobProgressData is ResourceJobProgressData)
            {
                if (_currentResourceCount < _unitConfig.MaxResourceOnUnit)
                {
                    if (IsWorking == false)
                    {
                        InvokeOnStartWorking();
                        IsWorking = true;
                    }

                    if (_jobProgressData.HasObjectJob)
                    {
                        UpdateProgress();
                    }

                    if (!_jobProgressData.HasObjectJob && IsWorking)
                    {
                        IsWorking = false;
                        _jobProgressData.WorkingWorkersListService.TryRemoveUnit(gameObject.GetComponent<IMoveble>());
                        InvokeOnStopWorking();
                    }
                }

                else
                {
                    if (IsWorking)
                    {
                        IsWorking = false;
                        _jobProgressData.WorkingWorkersListService.TryRemoveUnit(gameObject.GetComponent<IMoveble>());
                        InvokeOnStopWorking();
                    }
                }
            }

            if (IsWorking && (_jobProgressData == null || !IsDistanceEnoughToWork()))
            {
                IsWorking = false;
                InvokeOnStopWorking();
            }
        }

        private void UpdateProgress()
        {
            if (_currentCooldown <= 0)
            {

                if (_currentResourceCount + _unitConfig.Efficiency >= _unitConfig.MaxResourceOnUnit)
                {
                    _jobProgressData.UpdateProgress(_unitConfig.MaxResourceOnUnit - _currentResourceCount);
                    _currentResourceCount = _unitConfig.MaxResourceOnUnit;
                }

                else
                {
                    _jobProgressData.UpdateProgress(_unitConfig.Efficiency);
                    _currentResourceCount += _unitConfig.Efficiency;
                }

                _currentCooldown = _unitConfig.Cooldown;
            }

            else
            {
                _currentCooldown -= Time.deltaTime;
            }
        }

        private void TryAutoPutResourcesInCollector()
        {
            if (IsDistanceEnoughToCollecting() && !_jobProgressData.HasObjectJob)
            {
                _resourceCollector.AddResource(_currentResourceCount);
                _currentResourceCount = 0;
            }
        }

        private bool IsDistanceEnoughToCollecting()
        {
            return _resourceCollector != null &&
                   Vector3.Distance(transform.position, _resourceCollector.transform.position) <=
                   _unitConfig.DistanceForWork;
        }
    }
}