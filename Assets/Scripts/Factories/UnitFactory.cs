using UnityEngine;
using Zenject;

public class UnitFactory : IUnitFactory
{
    private const string KnightPath = "Units/Knight";
    private const string BowerPath = "Units/Bower";
    private const string WizardPath = "Units/Wizard";
    private const string WorkerPath = "Units/WK_worker";

    private readonly DiContainer _diContainer;

    public UnitFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject CreateUnit(Unit unit)
    {
        GameObject unitGameObject;
        switch (unit)
        {
            case Knight:
                unitGameObject = Resources.Load<GameObject>(KnightPath);
                return _diContainer.InstantiatePrefab(unitGameObject);
                
            case Bower:
                unitGameObject = Resources.Load<GameObject>(BowerPath);
                return _diContainer.InstantiatePrefab(unitGameObject);
                
            case Wizard:
                unitGameObject = Resources.Load<GameObject>(WizardPath);
                return _diContainer.InstantiatePrefab(unitGameObject);
            
            case Worker:
                unitGameObject = Resources.Load<GameObject>(WorkerPath);
                return _diContainer.InstantiatePrefab(unitGameObject);

        }
        return null;
    }
}