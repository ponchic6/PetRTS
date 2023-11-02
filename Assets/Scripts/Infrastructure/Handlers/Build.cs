using UnityEngine;
using Zenject;

public class Build : MonoBehaviour, ISelectable
{
    private SelectableListService _selectableListService;
    
    [Inject]
    public void Constructor(SelectableListService selectableListService)
    {
        _selectableListService = selectableListService;
        _selectableListService.AllSelectableUnits.Add(this);
    }
}