using UnityEngine;
using Zenject;

public class UnitButtonsHandler : MonoBehaviour
{
    private IWarriorFactory _warriorFactory;
    
    [Inject]
    public void Constructor(IWarriorFactory warriorFactory)
    {
        _warriorFactory = warriorFactory;
    }

    public void CreateKnight()
    {
        _warriorFactory.CreateKnight();
    }
    
    public void CreateBower()
    {
        _warriorFactory.CreateBower();
    }
    public void CreateWizard()
    {
        _warriorFactory.CreateWizard();
    }
}