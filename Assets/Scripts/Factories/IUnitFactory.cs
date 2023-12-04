using UnityEngine;

public interface IUnitFactory
{
    public GameObject CreateUnit(Unit unit, Transform building);
    public GameObject CreateUnit(Unit unit);
}