using UnityEngine;

public interface IUIHandlerFactory
{
    public BuildingButtonsHandler CreateBuildingButtonsHandler(Transform parent);
    public SelectorView CreateSelectorView();
}