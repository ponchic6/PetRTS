using Factories;
using Services;
using UnityEngine;

namespace Logic.MonoBehaviors.Mediators
{
    public class GlobalResourceAndUnitFactoryMediator : IGlobalResourceAndUnitFactoryMediator
    {   
        private readonly IUnitFactory _unitFactory;
        private readonly IGlobalResourcessStorageService _globalResourcessStorageService;
        
        public GlobalResourceAndUnitFactoryMediator(IUnitFactory unitFactory,
            IGlobalResourcessStorageService globalResourcessStorageService)
        {
            _unitFactory = unitFactory;
            _globalResourcessStorageService = globalResourcessStorageService;
        }
        
        public GameObject CreateUnit(UnitStaticData unitStaticData, Transform building)
        {
            if (_globalResourcessStorageService.StorageResource >= unitStaticData.Price)
            {
                _globalResourcessStorageService.RemoveResource(unitStaticData.Price);
                return _unitFactory.CreateUnit(unitStaticData, building);
            }

            return null;
        }
    }
}