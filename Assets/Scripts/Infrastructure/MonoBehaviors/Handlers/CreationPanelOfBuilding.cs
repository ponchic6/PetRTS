using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class CreationPanelOfBuilding : MonoBehaviour
{
    [SerializeField] private ViewSelectStatusChanger _viewSelectStatusChanger;
    [SerializeField] private List<UnitConfig> _creatableUnits;

    private List<Transform> _unitButtonsList;
    private SelectableListService _selectableListService;
    private IUIFactory _uiFactory;

    [Inject]
    public void Constructor(IUIFactory uiFactory, SelectableListService selectableListService)
    {
        _uiFactory = uiFactory;
        _selectableListService = selectableListService;

        _viewSelectStatusChanger.OnSelected += SwitchCreationPanelToCurrentBuildings;
        _viewSelectStatusChanger.OnDecelected += SwitchCreationPanelToAllBuildings;
    }

    private void SwitchCreationPanelToAllBuildings()
    {
        BuildingButtonsEnable();
        UnitButtonsDisable();
    }

    private void SwitchCreationPanelToCurrentBuildings()
    {
        if (_selectableListService.CurrentSelectUnits.Count == 1)
        {   
            BuildingButtonsDisable();
            UnitButtonsEnable();
        }
    }

    private void BuildingButtonsEnable()
    {   
        _uiFactory.BuildingButtonsRoot.gameObject.SetActive(true);
    }

    private void BuildingButtonsDisable()
    {
        _uiFactory.BuildingButtonsRoot.gameObject.SetActive(false);
    }

    private void UnitButtonsEnable()
    {
        if (_unitButtonsList == null)
        {
            _unitButtonsList = _uiFactory.CreateUnitButtonsForBuilding(_creatableUnits, _unitButtonsList);
        }

        foreach (Transform unitButton in _unitButtonsList)
        {
            unitButton.gameObject.SetActive(true);
        }
    }

    private void UnitButtonsDisable()
    {
        if (_unitButtonsList == null)
        {
            return;
        }
            
        foreach (Transform unitButton in _unitButtonsList)
        {
            Object.Destroy(unitButton.gameObject);
        }

        _unitButtonsList = null;
    }
}