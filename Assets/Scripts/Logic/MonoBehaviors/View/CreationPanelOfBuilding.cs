using System.Collections.Generic;
using UnityEngine;

public class CreationPanelOfBuilding : CreationPanelOfSelectedObject
{
    [SerializeField] private List<UnitConfig> _creatableUnits;
    private ProgressData _buildingProgressData;

    protected override void Awake()
    {
        base.Awake();
        
        _buildingProgressData = GetComponent<ProgressData>();
        _buildingProgressData.OnFinishedWorking += SwitchCreationPanelToCurrentObject;
    }

    protected override void SwitchCreationPanelToCurrentObject()
    {
        if (_buttonsListOfSelected == null &&
            _selectableListService.CurrentSelectObjects.Count == 1 &&
            !_buildingProgressData.HasObjectJob &&
            _viewSelectStatusChanger.IsSelect())
        {
            _buttonsListOfSelected = _uiFactory.CreateUnitCreationButtons(_creatableUnits, _buttonsListOfSelected, transform);
        }
    }
}