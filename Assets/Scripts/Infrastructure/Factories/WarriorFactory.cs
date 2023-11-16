using UnityEngine;
using Zenject;

public class WarriorFactory : IWarriorFactory
{
    private const string Warrior1Path = "Units/Knight";
    private const string Warrior2Path = "Units/Bower";
    private const string Warrior3Path = "Units/Wizard";

    private readonly DiContainer _diContainer;

    public WarriorFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject CreateKnight()
    {
        GameObject warrior = Resources.Load<GameObject>(Warrior1Path);
        return _diContainer.InstantiatePrefab(warrior);
    }

    public GameObject CreateBower()
    {
        GameObject warrior = Resources.Load<GameObject>(Warrior2Path);
        return _diContainer.InstantiatePrefab(warrior);
    }

    public GameObject CreateWizard()
    {
        GameObject warrior = Resources.Load<GameObject>(Warrior3Path);
        return _diContainer.InstantiatePrefab(warrior);
    }
}

