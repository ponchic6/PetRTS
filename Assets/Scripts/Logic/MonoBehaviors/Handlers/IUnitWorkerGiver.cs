using System;

public interface IUnitWorkerGiver
{
    public JobProgressData GetCurrentJopProgressData();
    public ResourceCollector GetCurrentResourcesCollector();
    public bool IsWorking { get; set; }
}