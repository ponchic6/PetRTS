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
    
    public void CreateKnight()
    {
        _unitFactory.CreateKnight();
    }

    public void CreateBower()
    {
        _unitFactory.CreateBower();
    }

    public void CreateWizard()
    {
        _unitFactory.CreateWizard();
    }
}