using UnityEngine;
using Zenject;

public class UIHandlerFactory : IUIHandlerFactory
{    
    private const string BuildingButtonsHandlerPath = "UIEllements/UIHandlers/BuildingButtonsHandler";
    private const string SelectorViewPath = "UIEllements/UIHandlers/SelectorView";
    
    private DiContainer _diContainer;

    public UIHandlerFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public BuildingButtonsHandler CreateBuildingButtonsHandler(Transform parent)
    {
        BuildingButtonsHandler buildingButtonsHandler = _diContainer.
            InstantiatePrefabResourceForComponent<BuildingButtonsHandler>(BuildingButtonsHandlerPath, parent);
        
        return buildingButtonsHandler;
    }

    public SelectorView CreateSelectorView()
    {
        SelectorView selectorView = _diContainer.
            InstantiatePrefabResourceForComponent<SelectorView>(SelectorViewPath);

        return selectorView;
    }
}