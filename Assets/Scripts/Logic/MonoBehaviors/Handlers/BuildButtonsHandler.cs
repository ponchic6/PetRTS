using UnityEngine;
using Zenject;

public class BuildButtonsHandler : MonoBehaviour
{
    private IBuildingFactory _buildingFactory;

    [Inject]
    public void Constructor(IBuildingFactory buildingFactory)
    {
        _buildingFactory = buildingFactory;
    }

    public void CreateBuilding(Building building)
    {
        _buildingFactory.CreateBuilding(building);
    }
}