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

    public void CreateWarrior()
    {
        _warriorFactory.CreateWarrior1();
    }
}