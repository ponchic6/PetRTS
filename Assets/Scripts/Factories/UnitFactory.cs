using UnityEngine;
using Zenject;

namespace Factories
{
    public class UnitFactory : IUnitFactory
    {
        private readonly DiContainer _diContainer;

        public UnitFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    
        public GameObject CreateUnit(UnitStaticData unitStaticData, Transform building)
        {
            GameObject unitGameObject = Resources.Load<GameObject>(unitStaticData.UnitPrefabPath);
            return _diContainer.InstantiatePrefab(unitGameObject, building.position, Quaternion.identity, null);
        }

        public GameObject CreateUnit(UnitStaticData unitStaticData)
        {
            GameObject unitGameObject = Resources.Load<GameObject>(unitStaticData.UnitPrefabPath);
            return _diContainer.InstantiatePrefab(unitGameObject);
        }
    }
}