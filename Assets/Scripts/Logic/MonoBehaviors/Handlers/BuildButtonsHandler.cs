using UnityEngine;
using Zenject;

public class BuildButtonsHandler : MonoBehaviour
{
    private IGlobalResourceAndBuildingFactoryMediator _buildingMediator;

    [Inject]
    public void Constructor(IGlobalResourceAndBuildingFactoryMediator buildingMediator)
    {
        _buildingMediator = buildingMediator;
    }

    public void CreateBuilding(BuildingStaticData building)
    {
        _buildingMediator.CreateBuilding(building);
    }
}