using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Static Data/Building Static Data", fileName = "BuildingStaticData")]
public class BuildingStaticData : ScriptableObject
{
    [SerializeField] private string _buildingPrefabPath;
    [SerializeField] private float _resourcePrice;
    [SerializeField] private string _buildingName;
    
    public string BuildingPrefabPath => _buildingPrefabPath;
    public float ResourcePrice => _resourcePrice;
    public string BuildingName => _buildingName;
}