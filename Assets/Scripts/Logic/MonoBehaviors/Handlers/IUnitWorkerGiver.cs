using System;

public interface IUnitWorkerGiver
{
    public JobProgressData GetCurrentJopProgressData();
    public ResourceCollector GetCurrentResourcesCollector();
}