using UnityEngine;

namespace Logic.MonoBehaviors.Mediators
{
    public interface IGlobalResourceAndBuildingFactoryMediator
    {
        public GameObject CreateBuilding(BuildingStaticData building);
    }
}