using UnityEngine;
using Zenject;

public class UnitButtonsHandler : MonoBehaviour
{
    private IUnitFactory _unitFactory;

    [Inject]
    public void Constructor(IUnitFactory unitFactory)
    {
        _unitFactory = unitFactory;
    }

    public void CreateUnit(Unit unit, Transform building)
    {
        _unitFactory.CreateUnit(unit, building);
    }
}