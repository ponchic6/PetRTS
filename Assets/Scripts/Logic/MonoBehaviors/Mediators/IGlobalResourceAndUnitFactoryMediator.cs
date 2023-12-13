using UnityEngine;

namespace Logic.MonoBehaviors.Mediators
{
    public interface IGlobalResourceAndUnitFactoryMediator
    {
        public GameObject CreateUnit(UnitStaticData unitStaticData, Transform building);
    }
}