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

    public GameObject CreateCastle()
    {
        GameObject buildPrefab = Resources.Load<GameObject>(CastlePath);
        GameObject build = _diContainer.InstantiatePrefab(buildPrefab); 
        OnCreateBuilding?.Invoke(build);
        return build;
    }

    public GameObject CreateTower()
    {
        GameObject buildPrefab = Resources.Load<GameObject>(TowerPath);
        GameObject build = _diContainer.InstantiatePrefab(buildPrefab); 
        OnCreateBuilding?.Invoke(build);
        return build;
    }

    public GameObject CreateMagicSchool()
    {
        GameObject buildPrefab = Resources.Load<GameObject>(MagicSchoolPath);
        GameObject build = _diContainer.InstantiatePrefab(buildPrefab); 
        OnCreateBuilding?.Invoke(build);
        return build;
    }
}