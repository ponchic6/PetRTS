using System;
using Logic.MonoBehaviors.Handlers;
using Logic.MonoBehaviors.View;
using Services;
using UnityEngine;
using Zenject;

namespace Logic.MonoBehaviors.Unit
{
    public class UnitWorkGiver : MonoBehaviour, IUnitWorkerGiver
    {
        public event Action<JobProgressData> OnJobProgressClick;
        public event Action<ResourceCollector> OnResourceCollectorClick;

        [SerializeField] private SelectStatusChanger _selectStatusChanger;

        private IInputService _inputService;

        [Inject]
        public void Constructor(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnRightClickDown += TrySetWorkPoint;
        }

        private void TrySetWorkPoint()
        {
            if (_selectStatusChanger.IsSelect())
            {
                Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
                Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity);

                TrySetJobProgressData(raycastHit);
                TrySetResourceCollector(raycastHit);
            }
        }

        private void TrySetJobProgressData(RaycastHit raycastHit)
        {
            if (raycastHit.collider.gameObject.TryGetComponent(out JobProgressData workableObject))
            {
                OnJobProgressClick?.Invoke(workableObject);
            }

            else
            {
                OnJobProgressClick?.Invoke(null);
            }
        }

        private void TrySetResourceCollector(RaycastHit raycastHit)
        {
            if (raycastHit.collider.gameObject.TryGetComponent(out ResourceCollector resourceCollector))
            {
                OnResourceCollectorClick?.Invoke(resourceCollector);
            }
        }
    }
}