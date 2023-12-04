using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField] private string _buildingName;

    public string GetBuildingName()
    {
        return _buildingName;
    }
}