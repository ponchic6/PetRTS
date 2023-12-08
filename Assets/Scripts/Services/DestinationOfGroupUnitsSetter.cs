using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestinationOfGroupUnitsSetter
{
    private readonly IInputService _inputService;
    private readonly SelectableListService _selectableListService;

    public DestinationOfGroupUnitsSetter(IInputService inputService, SelectableListService selectableListService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += SetDestinationForSelectedUnits;
        
        _selectableListService = selectableListService;
    }

    private void SetDestinationForSelectedUnits()
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
        RaycastHit raycastHit;
        
        if (Physics.Raycast(ray, out raycastHit))
        {
            switch (raycastHit.collider.gameObject.layer)
            {
                case 6:
                    SetDestinationOnGroundClick(raycastHit);
                    break;
                
                case 7:
                    SetDestinationOnWorkableObject(raycastHit);
                    break;
            }
        }
    }

    private void SetDestinationOnGroundClick(RaycastHit raycastHit)
    {
        List<IMoveble> _currentSelectUnits = FillCurrentSelectMovebleUnitList();

        int numberInColumn = Mathf.RoundToInt(Mathf.Sqrt(_currentSelectUnits.Count));

        int i = 0;
        int j = 0;

        Vector3 midlePoint = new Vector3();

        foreach (IMoveble unit in _currentSelectUnits)
        {
            midlePoint += unit.GetTransform().position / _currentSelectUnits.Count;
        }

        Vector3 verticalDirection = (raycastHit.point - midlePoint).normalized / 1.6f;
        Vector3 horizontalDirecton = new Vector3(1, 0, -(verticalDirection.x / verticalDirection.z)).normalized / 1.6f;

        foreach (IMoveble unit in _currentSelectUnits)
        {
            unit.MoveToDestination(raycastHit.point +
                                   (i - Mathf.RoundToInt(numberInColumn / 2)) * verticalDirection +
                                   (j - Mathf.RoundToInt(numberInColumn / 2)) * horizontalDirecton);
            i++;

            if (i == numberInColumn)
            {
                i = 0;
                j += 1;
            }
        }
    }

    private void SetDestinationOnWorkableObject(RaycastHit raycastHit)
    {
        JobProgressData jobProgressData = raycastHit.collider.GetComponent<JobProgressData>();
        IWorkingWorkersList workingWorkersList = raycastHit.collider.GetComponent<IWorkingWorkersList>();
        
        List<IMoveble> currentUnits = FillCurrentSelectMovebleUnitList();
        
        foreach (IMoveble unit in currentUnits)
        {
            workingWorkersList.AddUnit(unit);
        }

        float degreeOnUnit = 360 / workingWorkersList.Count();
        Vector3 directionToDestination = jobProgressData.gameObject.transform.forward;
        
        foreach (IMoveble unit in workingWorkersList.GetList())
        {   
            unit.GetTransform().GetComponent<SelectStatusChanger>().Select();
            unit.MoveToDestination(directionToDestination * (unit.GetUnitStaticData().DistanceForWork - 0.1f) +
                                   jobProgressData.gameObject.transform.position, jobProgressData.gameObject);
            directionToDestination =
                Quaternion.AngleAxis(degreeOnUnit, Vector3.up) * directionToDestination;
        }
    }

    private List<IMoveble> FillCurrentSelectMovebleUnitList()
    {
        List<IMoveble> currentUnits = new List<IMoveble>();

        foreach (SelectStatusChanger unit in _selectableListService.CurrentSelectObjects)
        {
            if (unit.TryGetComponent(out IMoveble unitMover))
            {
                currentUnits.Add(unitMover);
            }
        }

        return currentUnits;
    }
}