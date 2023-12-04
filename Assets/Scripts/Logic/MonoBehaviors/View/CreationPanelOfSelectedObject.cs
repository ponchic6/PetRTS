using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class CreationPanelOfSelectedObject : MonoBehaviour
{
    protected List<Transform> _buttonsList;
    protected SelectableListService _selectableListService;
    protected IUIFactory _uiFactory;

    private ViewSelectStatusChanger _viewSelectStatusChanger;

    protected virtual void Awake()
    {
        _viewSelectStatusChanger = GetComponent<ViewSelectStatusChanger>();
        
        _viewSelectStatusChanger.OnSelected += SwitchCreationPanelToCurrentObject;
        _viewSelectStatusChanger.OnDecelected += SwitchCreationPanelToIdle;
    }

    protected abstract void SwitchCreationPanelToCurrentObject();

    [Inject]
    public void Constructor(IUIFactory uiFactory, SelectableListService selectableListService)
    {
        _uiFactory = uiFactory;
        _selectableListService = selectableListService;
    }

    private void SwitchCreationPanelToIdle()
    {
        if (_buttonsList == null)
        {
            return;
        }

        foreach (Transform button in _buttonsList)
        {
            Destroy(button.gameObject);
        }

        _buttonsList = null;
    }
}