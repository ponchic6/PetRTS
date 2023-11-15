using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreationPanelSwitcherToCurrentBuilding : MonoBehaviour
{
    [SerializeField] private ViewSelectStatusChanger _viewSelectStatusChanger;

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
        _uiFactory.UnitsButtons.GetChild(0).gameObject.SetActive(false);
    }

    private void CreationPanelToCurrentBuildings()
    {
        if (_selectableListService.CurrentSelectUnits.Count == 1)
        {
            _uiFactory.BuildingButtons.gameObject.SetActive(false);
            _uiFactory.UnitsButtons.GetChild(0).gameObject.SetActive(true);
        }
    }
}
