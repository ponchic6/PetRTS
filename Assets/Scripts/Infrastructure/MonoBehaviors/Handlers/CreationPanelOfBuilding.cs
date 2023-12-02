using System.Collections.Generic;
using UnityEngine;

public class CreationPanelOfBuilding : CreationPanelOfSelectedObject
{
    [SerializeField] private List<UnitConfig> _creatableUnits;
    
    protected override void SwitchCreationPanelToCurrentObject()
    {
        if (_buttonsList == null && _selectableListService.CurrentSelectUnits.Count == 1)
        {
            _buttonsList = _uiFactory.CreateUnitCreationButtons(_creatableUnits, _buttonsList);
        }
    }
}