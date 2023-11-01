using UnityEngine;

public interface IUIHandlerFactory
{
    public BuildingButtonsHandler CreateBuildingButtonsHandler(Transform parent);
}