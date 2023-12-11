using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestinationOfGroupUnitsSetter : IDestinationOfGroupUnitsSetter
{
    private readonly IInputService _inputService;
    private readonly SelectableListService _selectableListService;

    public DestinationOfGroupUnitsSetter(IInputService inputService, SelectableListService selectableListService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += SetDestinationForSelectedUnits;
        
        _selectableListService = selectableListService;
    }

    private void SetDestinationOnGround(RaycastHit raycastHit)
    {
        List<IMoveble> _currentSelectUnits = FillCurrentSelectMovebleUnitList();

        int numberInColumn = Mathf.RoundToInt(Mathf.Sqrt(_currentSelectUnits.Count));

        int i = 0;
        int j = 0;

        Vector3 midlePoint = new Vector3();

        foreach (IMoveble unit in _currentSelectUnits)
        {
            midlePoint += unit.Transform.position / _currentSelectUnits.Count;
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
    
    private void SetDestinationForSelectedUnits()
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
        RaycastHit raycastHit;
        
        if (Physics.Raycast(ray, out raycastHit))
        {
            switch (raycastHit.collider.gameObject.layer)
            {
                case 6:
                    SetDestinationOnGround(raycastHit);
                    break;
            }
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