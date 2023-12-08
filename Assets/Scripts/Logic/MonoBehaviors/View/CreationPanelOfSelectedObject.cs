using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public abstract class CreationPanelOfSelectedObject : MonoBehaviour
{
    [SerializeField] protected SelectStatusChanger selectStatusChanger;
    protected List<Transform> _buttonsListOfSelected;
    protected SelectableListService _selectableListService;
    protected IUIFactory _uiFactory;

    protected virtual void Awake()
    {
        selectStatusChanger.OnSelected += SwitchCreationPanelToCurrentObject;
        selectStatusChanger.OnDecelected += SwitchCreationPanelToIdle;
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
        if (_buttonsListOfSelected == null)
        {
            return;
        }

        foreach (Transform button in _buttonsListOfSelected)
        {
            Destroy(button.gameObject);
        }

        _buttonsListOfSelected = null;
    }
}