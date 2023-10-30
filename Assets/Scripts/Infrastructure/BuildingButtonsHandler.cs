using UnityEngine;
using Zenject;

public class BuildingButtonsHandler : MonoBehaviour
{
    private BuildingService _buildingService;
    
    [Inject]
    public void Constructor(BuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    public void CreateBuilding()
    {
        _buildingService.CreateBuilding();
    }
}