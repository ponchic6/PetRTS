using UnityEngine;
using Zenject;

public class WarriorFactory : IWarriorFactory
{
    private const string Warrior1Path = "Units/Warrior1";
    private const string Warrior2Path = "Units/Warrior2";
    private const string Warrior3Path = "Units/Warrior3";

    private readonly DiContainer _diContainer;

    public WarriorFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject CreateWarrior1()
    {
        GameObject warrior = Resources.Load<GameObject>(Warrior1Path);
        return _diContainer.InstantiatePrefab(warrior);
    }

    public GameObject CreateWarrior2()
    {
        GameObject warrior = Resources.Load<GameObject>(Warrior2Path);
        return _diContainer.InstantiatePrefab(warrior);
    }

    public GameObject CreateWarrior3()
    {
        GameObject warrior = Resources.Load<GameObject>(Warrior3Path);
        return _diContainer.InstantiatePrefab(warrior);
    }
}

