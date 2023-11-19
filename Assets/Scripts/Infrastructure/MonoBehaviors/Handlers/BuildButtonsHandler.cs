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

    public void CreateCastle()
    {
        _buildingFactory.CreateCastle();
    }

    public void CreateTower()
    {
        _buildingFactory.CreateTower();
    }

    public void CreateMagicSchool()
    {
        _buildingFactory.CreateMagicSchool();
    }
    

}