using System;
using UnityEngine;
using Zenject;

public class BuildingFactory : IBuildingFactory
{
    public event Action<GameObject> OnCreateBuilding;
    
    private readonly DiContainer _diContainer;

    public BuildingFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject CreateBuilding(BuildingStaticData buildingData)
    {
        GameObject building = _diContainer.InstantiatePrefabResource(buildingData.BuildingPrefabPath);
        OnCreateBuilding?.Invoke(building);
        return building;
    }
}