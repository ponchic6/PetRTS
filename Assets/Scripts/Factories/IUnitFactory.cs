using UnityEngine;

public interface IUnitFactory
{
    public GameObject CreateUnit(UnitTypeEnum unit, Transform building);
    public GameObject CreateUnit(UnitTypeEnum unit);
}