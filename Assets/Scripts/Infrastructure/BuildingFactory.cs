using UnityEngine;

public class BuildingFactory
{
    private const string Build1Path = "Buildings/Build1";
    
    public GameObject CreateBuilding()
    {    
        GameObject build = Resources.Load<GameObject>(Build1Path);
        return Object.Instantiate(build);
    }
}