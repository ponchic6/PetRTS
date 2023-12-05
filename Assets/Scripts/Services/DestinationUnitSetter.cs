using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationUnitSetter : IDestinationUnitSetter
{

    private readonly IInputService _inputService;
    private readonly SelectableListService _selectableListService;

    private Vector3 _destination;

    public DestinationUnitSetter(IInputService inputService, SelectableListService selectableListService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += SetDestinationForSelectedUnits;
        
        _selectableListService = selectableListService;
    }

    private void SetDestinationForSelectedUnits()
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, 1 << 6))
        {
            List<IMoveble> _currentSelectUnits = new List<IMoveble>();

            foreach (ViewSelectStatusChanger unit in _selectableListService.CurrentSelectObjects)
            {
                if (unit.TryGetComponent(out IMoveble unitMover))
                {
                    _currentSelectUnits.Add(unitMover);
                }
            }
            
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
    }
}