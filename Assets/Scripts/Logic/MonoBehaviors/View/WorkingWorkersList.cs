using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class WorkingWorkersList : MonoBehaviour, IWorkingWorkersList
{
    public List<IMoveble> workingWorkers = new List<IMoveble>();
    
    public List<IMoveble> GetList()
    {
        return workingWorkers;
    }
    
    public void TryRemoveUnit(IMoveble unit)
    {
        if (workingWorkers.Contains(unit))
        {
            workingWorkers.Remove(unit);
        }
    }
}