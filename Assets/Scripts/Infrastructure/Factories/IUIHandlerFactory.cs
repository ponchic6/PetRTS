using UnityEngine;

public interface IUIHandlerFactory
{
    public BuildButtonsHandler CreateBuildingButtonsHandler(Transform parent);
    public SelectorView CreateSelectorView();
}