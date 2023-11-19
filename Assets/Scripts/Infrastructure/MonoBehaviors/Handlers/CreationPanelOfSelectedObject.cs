using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class CreationPanelOfSelectedObject : MonoBehaviour
{
    protected List<Transform> _buttonsList;
    protected SelectableListService _selectableListService;
    protected IUIFactory _uiFactory;

    [SerializeField] private ViewSelectStatusChanger _viewSelectStatusChanger;

    [Inject]
    public void Constructor(IUIFactory uiFactory, SelectableListService selectableListService)
    {
        _uiFactory = uiFactory;
        _selectableListService = selectableListService;

        _viewSelectStatusChanger.OnSelected += SwitchCreationPanelToCurrentObject;
        _viewSelectStatusChanger.OnDecelected += SwitchCreationPanelToIdle;
    }

    protected abstract void SwitchCreationPanelToCurrentObject();

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