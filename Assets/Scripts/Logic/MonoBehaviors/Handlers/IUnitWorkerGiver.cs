using System;

public interface IUnitWorkerGiver
{
    public event Action<JobProgressData> OnJobProgressClick;
    public event Action<ResourceCollector> OnResourceCollectorClick;
}