using System;

public interface IUnitWorkerGiver
{
    public event Action<ProgressData> OnAvailabilityProgressData;
    public bool IsWorking { get; set; }
}