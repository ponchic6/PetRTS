using System.Collections.Generic;
using UnityEngine;

namespace Logic.MonoBehaviors.View
{
    public class CreationPanelOfUnit : CreationPanelOfSelectedObject
    {
        [SerializeField] private List<BuildingStaticData> _creatableBuildings;

        protected override void SwitchCreationPanelToCurrentObject()
        {
            if (_buttonsListOfSelected == null && _selectableListService.CurrentSelectObjects.Count == 1)
            {
                _buttonsListOfSelected = _uiFactory.CreateBuildingCreationButtonsOfUnit(_creatableBuildings);
            }
        }
    }
}