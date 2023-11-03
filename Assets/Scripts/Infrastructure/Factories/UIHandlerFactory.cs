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

    public BuildButtonsHandler CreateBuildingButtonsHandler(Transform parent)
    {    
        
        BuildButtonsHandler buildButtonsHandler = _diContainer.
            InstantiatePrefabResourceForComponent<BuildButtonsHandler>(BuildingButtonsHandlerPath, parent);
        return buildButtonsHandler;
    }

    public SelectorView CreateViewSelector()
    {
        SelectorView selectorView = _diContainer.
            InstantiatePrefabResourceForComponent<SelectorView>(SelectorViewPath);

        return selectorView;
    }
}