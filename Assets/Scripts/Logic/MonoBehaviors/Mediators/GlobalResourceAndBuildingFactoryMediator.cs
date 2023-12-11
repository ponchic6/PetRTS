using UnityEngine;
using Zenject;

public class GlobalResourceAndBuildingFactoryMediator : IGlobalResourceAndBuildingFactoryMediator
{
    private IBuildingFactory _buildingFactory;
    private IGlobalResourcessStorageService _globalResourcessStorageService;

    private float _resourcePrice = 50;
    
    public GlobalResourceAndBuildingFactoryMediator(IBuildingFactory buildingFactory,
        IGlobalResourcessStorageService globalResourcessStorageService)
    {
        _buildingFactory = buildingFactory;
        _globalResourcessStorageService = globalResourcessStorageService;
    }

    public GameObject CreateBuilding(BuildingStaticData building)
    {
        if (_globalResourcessStorageService.StorageResource >= _resourcePrice)
        {
            _globalResourcessStorageService.RemoveResource(_resourcePrice);
            return _buildingFactory.CreateBuilding(building);
        }

        return null;
    }
}