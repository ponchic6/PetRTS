using UnityEngine;

public class BuildingFactory : IBuildingFactory
{
    private const string Build1Path = "Buildings/Build1";
    
    public GameObject CreateBuilding1()
    {    
        GameObject build = Resources.Load<GameObject>(Build1Path);
        return Object.Instantiate(build);
    }
}