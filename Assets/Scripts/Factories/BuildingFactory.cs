using System;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        public event Action<GameObject> OnCreatedBuilding;
    
        private readonly DiContainer _diContainer;

        public BuildingFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreateBuilding(BuildingStaticData buildingData)
        {
            GameObject building = _diContainer.InstantiatePrefabResource(buildingData.BuildingPrefabPath);
            OnCreatedBuilding?.Invoke(building);
            return building;
        }
    }
}