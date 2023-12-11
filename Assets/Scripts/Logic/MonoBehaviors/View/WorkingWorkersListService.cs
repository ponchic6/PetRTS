using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class WorkingWorkersListService : MonoBehaviour, IWorkingWorkersListService
{
    private List<IMoveble> workingWorkers = new List<IMoveble>();
    
    public List<IMoveble> GetList()
    {
        return workingWorkers;
    }

    public void TryAdd(IMoveble unit)
    {
        if (!workingWorkers.Contains(unit))
        {
            workingWorkers.Add(unit);
        }
    }

    public void TryRemoveUnit(IMoveble unit)
    {
        if (workingWorkers.Contains(unit))
        {
            workingWorkers.Remove(unit);
        }
    }

    public void SetDestination(IMoveble unitMover)
    {   
        TryAdd(unitMover);
        
        float degreeOnUnit = 360 / workingWorkers.Count;
        Vector3 directionToDestination = transform.forward;
        
        foreach (IMoveble unit in workingWorkers)
        {
            if (unit.Transform.GetComponent<SelectStatusChanger>().IsSelect())
            {
                unit.MoveToDestination(directionToDestination * (unit.UnitStaticData.DistanceForWork - 0.1f) +
                                       transform.position, gameObject);
                directionToDestination =
                    Quaternion.AngleAxis(degreeOnUnit, Vector3.up) * directionToDestination;    
            }

            else
            {
                unit.Transform.GetComponent<SelectStatusChanger>().Select();
                unit.MoveToDestination(directionToDestination * (unit.UnitStaticData.DistanceForWork - 0.1f) +
                                       transform.position, gameObject);
                directionToDestination =
                    Quaternion.AngleAxis(degreeOnUnit, Vector3.up) * directionToDestination;
                unit.Transform.GetComponent<SelectStatusChanger>().Deselect();
            }

        }
    }
}