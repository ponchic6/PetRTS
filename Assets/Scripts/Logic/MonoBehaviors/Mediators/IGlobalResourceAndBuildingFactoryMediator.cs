using System;
using UnityEngine;

public interface IGlobalResourceAndBuildingFactoryMediator
{
    public GameObject CreateBuilding(BuildingStaticData building);
}