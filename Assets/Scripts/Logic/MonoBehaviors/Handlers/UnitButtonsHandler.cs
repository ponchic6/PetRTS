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

    public void CreateUnit(Unit unit)
    {
        _unitFactory.CreateUnit(unit);
    }
}