using UnityEngine;
using Zenject;

public class BuildingFactory : IBuildingFactory
{
    private const string Build1Path = "Buildings/Build1";
    private const string Build2Path = "Buildings/Build2";
    private const string Build3Path = "Buildings/Build3";

    private readonly DiContainer _diContainer;

    public BuildingFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject CreateBuilding1()
    {
        GameObject build = Resources.Load<GameObject>(Build1Path);
        return _diContainer.InstantiatePrefab(build);
    }

    public GameObject CreateBuilding2()
    {
        GameObject build = Resources.Load<GameObject>(Build2Path);
        return _diContainer.InstantiatePrefab(build);
    }

    public GameObject CreateBuilding3()
    {
        GameObject build = Resources.Load<GameObject>(Build3Path);
        return _diContainer.InstantiatePrefab(build);
    }
}