using UnityEngine;

namespace Factories
{
    public interface IUnitFactory
    {
        public GameObject CreateUnit(UnitStaticData unitStaticData, Transform building);
        public GameObject CreateUnit(UnitStaticData unitStaticData);
    }
}