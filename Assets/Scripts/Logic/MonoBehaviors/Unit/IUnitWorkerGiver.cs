using System;
using Logic.MonoBehaviors.Handlers;
using Logic.MonoBehaviors.View;

namespace Logic.MonoBehaviors.Unit
{
    public interface IUnitWorkerGiver
    {
        public event Action<JobProgressData> OnJobProgressClick;
        public event Action<ResourceCollector> OnResourceCollectorClick;
    }
}