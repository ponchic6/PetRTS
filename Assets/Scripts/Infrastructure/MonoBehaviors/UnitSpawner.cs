using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class UnitSpawner : MonoBehaviour, IUnitSpawner
{
    [SerializeField] private float _spawnCooldown;

    private IWarriorFactory _warriorFactory;

    [Inject]
    public void Constructor(IWarriorFactory warriorFactory)
    {
        _warriorFactory = warriorFactory;
    }

    public void StartSpawner()
    {
        StartCoroutine(CoroutineSpawner());
    }

    public void EndSpawner()
    {
        StopCoroutine(CoroutineSpawner());
    }

    private IEnumerator CoroutineSpawner()
    {
        while (true)
        {
            GameObject warrior = _warriorFactory.CreateKnight();
            SetWarriorPos(warrior);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void SetWarriorPos(GameObject warrior)
    {
        warrior.transform.position = transform.position +
                                     new Vector3(Random.Range(0, 5), 0.25f, Random.Range(0, 5));
    }
}