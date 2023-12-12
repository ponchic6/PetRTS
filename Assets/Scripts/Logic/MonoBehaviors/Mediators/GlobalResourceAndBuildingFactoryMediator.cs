using Factories;
using Services;
using UnityEngine;

namespace Logic.MonoBehaviors.Mediators
{
    public class GlobalResourceAndBuildingFactoryMediator : IGlobalResourceAndBuildingFactoryMediator
    {
        private readonly IBuildingFactory _buildingFactory;
        private readonly IGlobalResourcessStorageService _globalResourcessStorageService;

        public GlobalResourceAndBuildingFactoryMediator(IBuildingFactory buildingFactory,
            IGlobalResourcessStorageService globalResourcessStorageService)
        {
            _buildingFactory = buildingFactory;
            _globalResourcessStorageService = globalResourcessStorageService;
        }

        public GameObject CreateBuilding(BuildingStaticData building)
        {
            if (_globalResourcessStorageService.StorageResource >= building.ResourcePrice)
            {
                _globalResourcessStorageService.RemoveResource(building.ResourcePrice);
                return _buildingFactory.CreateBuilding(building);
            }

            return null;
        }
    }
}