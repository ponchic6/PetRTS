using System.Collections.Generic;
using UnityEngine;

public class CreationPanelOfBuilding : CreationPanelOfSelectedObject
{
    [SerializeField] private List<UnitConfig> _creatableUnits;
    private IConstructionProgressView _constructionProgressView;

    protected override void Awake()
    {
        base.Awake();
        
        _constructionProgressView = GetComponent<IConstructionProgressView>();
        _constructionProgressView.OnBuilded += SwitchCreationPanelToCurrentObject;
    }

    protected override void SwitchCreationPanelToCurrentObject()
    {
        if (_buttonsListOfSelected == null &&
            _selectableListService.CurrentSelectObjects.Count == 1 &&
            _constructionProgressView.IsBuilded &&
            _viewSelectStatusChanger.IsSelect())
        {
            _buttonsListOfSelected = _uiFactory.CreateUnitCreationButtons(_creatableUnits, _buttonsListOfSelected, transform);
        }
    }
}