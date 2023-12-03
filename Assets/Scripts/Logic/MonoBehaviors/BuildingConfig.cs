using UnityEngine;

public class BuildingConfig : MonoBehaviour
{
    [SerializeField] private BuildingType _buildingType;
    public BuildingType Type => _buildingType;
    
    public string GetBuildName()
    {
        return Type.ToString();
    }
}