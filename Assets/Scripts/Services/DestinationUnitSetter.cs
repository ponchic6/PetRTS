using System;
using UnityEngine;

public class DestinationUnitSetter : IDestinationUnitSetter
{
    public event Action<Vector3> OnSetDestination;

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
            _destination = raycastHit.point;
        }

        OnSetDestination?.Invoke(_destination);
    }
}