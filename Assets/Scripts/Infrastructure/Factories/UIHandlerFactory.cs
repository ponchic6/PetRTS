using UnityEngine;
using Zenject;

public class UIHandlerFactory : IUIHandlerFactory
{    
    private const string BuildingButtonsHandlerPath = "UIEllements/UIHandlers/BuildingButtonsHandler";
    private const string SelectorViewPath = "UIEllements/UIHandlers/SelectorView";
    private const string UnitbuttonsHandlerPath = "UIEllements/UIHandlers/UnitButtonsHandler";

    private DiContainer _diContainer;

    public UIHandlerFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public BuildButtonsHandler CreateBuildingButtonsHandler(Transform parent)
    {
        BuildButtonsHandler buildButtonsHandler = _diContainer.
            InstantiatePrefabResourceForComponent<BuildButtonsHandler>(BuildingButtonsHandlerPath, parent);
        
        return buildButtonsHandler;
    }

    public UnitButtonsHandler CreateUnitButtonsHandler(Transform parent)
    {
        UnitButtonsHandler unitButtonsHandler = _diContainer.
            InstantiatePrefabResourceForComponent<UnitButtonsHandler>(UnitbuttonsHandlerPath, parent);
        
        return unitButtonsHandler;

    }

    public SelectorView CreateSelectorView()
    {
        SelectorView selectorView = _diContainer.
            InstantiatePrefabResourceForComponent<SelectorView>(SelectorViewPath);

        return selectorView;
    }
}