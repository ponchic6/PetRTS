using System.Collections.Generic;
using UnityEngine;

public class CreationPanelOfUnit : CreationPanelOfSelectedObject
{
    [SerializeField] private List<Building> _creatableBuildings;

    protected override void SwitchCreationPanelToCurrentObject()
    {
        if (_buttonsListOfSelected == null && _selectableListService.CurrentSelectObjects.Count == 1)
        {
            _buttonsListOfSelected = _uiFactory.CreateBuildingCreationButtons(_creatableBuildings, _buttonsListOfSelected);
        }
    }
}