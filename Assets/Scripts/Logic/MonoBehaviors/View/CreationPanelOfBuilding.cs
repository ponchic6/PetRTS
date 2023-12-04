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
    }

    protected override void SwitchCreationPanelToCurrentObject()
    {
        if (_buttonsList == null &&
            _selectableListService.CurrentSelectUnits.Count == 1 &&
            _constructionProgressView.IsBuilded)
        {
            _buttonsList = _uiFactory.CreateUnitCreationButtons(_creatableUnits, _buttonsList);
        }
    }
}