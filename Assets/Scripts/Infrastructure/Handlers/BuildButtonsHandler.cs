using UnityEngine;
using Zenject;

public class BuildButtonsHandler : MonoBehaviour
{
    private IBuildingService _buildingService;
    
    [Inject]
    public void Constructor(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    public void CreateBuilding(int buildingNumber)
    {
        _buildingService.CreateBuilding(buildingNumber);
    }
}