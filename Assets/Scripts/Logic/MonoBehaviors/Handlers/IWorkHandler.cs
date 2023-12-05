using System;

public interface IWorkHandler
{
    public bool IsWorking { get; }
    public ProgressData GetProgressData();
}