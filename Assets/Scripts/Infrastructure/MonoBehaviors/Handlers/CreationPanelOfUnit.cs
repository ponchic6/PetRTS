using System.Collections.Generic;
using UnityEngine;

public class CreationPanelOfUnit : CreationPanelOfSelectedObject
{
    [SerializeField] private List<BuildingConfig> _creatableBuildings;

    protected override void SwitchCreationPanelToCurrentObject()
    {
        if (_buttonsList == null && _selectableListService.CurrentSelectUnits.Count == 1)
        {
            _buttonsList = _uiFactory.CreateBuildingCreationButtons(_creatableBuildings, _buttonsList);
        }
    }
}