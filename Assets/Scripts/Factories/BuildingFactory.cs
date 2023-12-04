using System;
using UnityEngine;
using Zenject;

public class BuildingFactory : IBuildingFactory
{
    public event Action<GameObject> OnCreateBuilding;
    
    private const string CastlePath = "Buildings/Castle";
    private const string TowerPath = "Buildings/Tower";
    private const string MagicSchoolPath = "Buildings/MagisSchool";

    private readonly DiContainer _diContainer;

    public BuildingFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject CreateBuilding(Building building)
    {
        GameObject currentBuilding;
        GameObject builingPrefab;
        
        switch (building)
        {
            case Castle:
                builingPrefab = Resources.Load<GameObject>(CastlePath);
                currentBuilding = _diContainer.InstantiatePrefab(builingPrefab);
                OnCreateBuilding?.Invoke(currentBuilding);
                return currentBuilding;
                
            case Tower:
                builingPrefab = Resources.Load<GameObject>(TowerPath);
                currentBuilding = _diContainer.InstantiatePrefab(builingPrefab);
                OnCreateBuilding?.Invoke(currentBuilding);
                return currentBuilding;
                
            case WizardSchool:
                builingPrefab = Resources.Load<GameObject>(MagicSchoolPath);
                currentBuilding = _diContainer.InstantiatePrefab(builingPrefab);
                OnCreateBuilding?.Invoke(currentBuilding);
                return currentBuilding;
        }
        return null;
    }
}