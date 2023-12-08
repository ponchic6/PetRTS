using UnityEngine;

public interface IUnitFactory
{
    public GameObject CreateUnit(UnitStaticData unitStaticData, Transform building);
    public GameObject CreateUnit(UnitStaticData unitStaticData);
}