using System;
using UnityEngine;

namespace Factories
{
    public interface IBuildingFactory
    {
        public event Action<GameObject> OnCreatedBuilding;
        public GameObject CreateBuilding(BuildingStaticData building);
    }
}