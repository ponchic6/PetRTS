using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreationPanelSwitcherToCurrentBuilding : MonoBehaviour
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
        
        _viewSelectStatusChanger.OnSelected += CreationPanelToCurrentBuildings;
        _viewSelectStatusChanger.OnDecelected += CreationPanelToAllBuildings;
    }

    private void CreationPanelToAllBuildings()
    {
        _uiFactory.BuildingButtons.gameObject.SetActive(true);
        UnitButtonsDisable();
    }

    private void CreationPanelToCurrentBuildings()
    {   
        if (_unitButtonsList == null) 
            CreateUnitButtons();

        if (_selectableListService.CurrentSelectUnits.Count == 1)
        {
            _uiFactory.BuildingButtons.gameObject.SetActive(false);
            UnitButtonsEnable();
        }
    }

    private void UnitButtonsDisable()
    {
        foreach (Transform button in _unitButtonsList)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void UnitButtonsEnable()
    {
        foreach (Transform button in _unitButtonsList)
        {
            button.gameObject.SetActive(true);
        }
        
    }

    private void CreateUnitButtons()
    {
        _unitButtonsList = new List<Transform>();

        int i = 0;
        foreach (UnitConfig config in _creatableUnits)
        {
            Transform button = _uiFactory.CreateUnitButton(config);
            button.position += new Vector3(0, -65, 0) * i;
            _unitButtonsList.Add(button);
            i++;
        }
    }
}
