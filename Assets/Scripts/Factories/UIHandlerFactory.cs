using Logic.MonoBehaviors.Handlers;
using Logic.MonoBehaviors.View;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class UIHandlerFactory : IUIHandlerFactory
    {
        private readonly DiContainer _diContainer;
        private readonly UIHandlerStaticData _uiHandlerStaticData;
    
        public UIHandlerFactory(DiContainer diContainer, UIHandlerStaticData uiHandlerStaticData)
        {
            _diContainer = diContainer;
            _uiHandlerStaticData = uiHandlerStaticData;
        }

        public BuildingButtonsHandler CreateBuildingButtonsHandler(Transform parent)
        {
            BuildingButtonsHandler buildingButtonsHandler =
                _diContainer.InstantiatePrefabResourceForComponent<BuildingButtonsHandler>(_uiHandlerStaticData.BuildingButtonsHandlerPath, parent);

            return buildingButtonsHandler;
        }

        public UnitButtonsHandler CreateUnitButtonsHandler(Transform parent)
        {
            UnitButtonsHandler unitButtonsHandler =
                _diContainer.InstantiatePrefabResourceForComponent<UnitButtonsHandler>(_uiHandlerStaticData.UnitbuttonsHandlerPath, parent);

            return unitButtonsHandler;
        }

        public void CreateSelectorView()
        {
            SelectorView selectorView = _diContainer.InstantiatePrefabResourceForComponent<SelectorView>(_uiHandlerStaticData.SelectorViewPath);
        }
    }
}