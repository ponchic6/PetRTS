using UnityEngine;

public class BuildingFactory : IBuildingFactory
{
    private const string Build1Path = "Buildings/Build1";
    private const string Build2Path = "Buildings/Build2";
    private const string Build3Path = "Buildings/Build3";
    public GameObject CreateBuilding1()
    {    
        GameObject build = Resources.Load<GameObject>(Build1Path);
        return Object.Instantiate(build);
    }
    public GameObject CreateBuilding2()
    {    
        GameObject build = Resources.Load<GameObject>(Build2Path);
        return Object.Instantiate(build);
    }
    public GameObject CreateBuilding3()
    {    
        GameObject build = Resources.Load<GameObject>(Build3Path);
        return Object.Instantiate(build);
    }
}