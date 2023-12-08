using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class WorkingWorkersList : MonoBehaviour, IWorkingWorkersList
{
    public List<IMoveble> workingWorkers = new List<IMoveble>();

    private void Update()
    {
        Debug.Log(workingWorkers.Count);
    }

    public List<IMoveble> GetList()
    {
        return workingWorkers;
    }

    public void AddUnit(IMoveble unit)
    {
        workingWorkers.Add(unit);
    }

    public void TryRemoveUnit(IMoveble unit)
    {
        if (workingWorkers.Contains(unit))
        {
            workingWorkers.Remove(unit);
        }
    }

    public float Count()
    {
        return workingWorkers.Count;
    }
}