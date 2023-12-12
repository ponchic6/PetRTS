using Logic.MonoBehaviors.Mediators;
using UnityEngine;
using Zenject;

namespace Logic.MonoBehaviors.Handlers
{
    public class BuildingButtonsHandler : MonoBehaviour
    {
        private IGlobalResourceAndBuildingFactoryMediator _buildingMediator;

        [Inject]
        public void Constructor(IGlobalResourceAndBuildingFactoryMediator buildingMediator)
        {
            _buildingMediator = buildingMediator;
        }

        public void CreateBuilding(BuildingStaticData building)
        {
            _buildingMediator.CreateBuilding(building);
        }
    }
}