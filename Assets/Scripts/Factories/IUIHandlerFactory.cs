using Logic.MonoBehaviors.Handlers;
using UnityEngine;

namespace Factories
{
    public interface IUIHandlerFactory
    {
        public BuildingButtonsHandler CreateBuildingButtonsHandler(Transform parent);
        public UnitButtonsHandler CreateUnitButtonsHandler(Transform parent);
        public void CreateSelectorView();
    }
}