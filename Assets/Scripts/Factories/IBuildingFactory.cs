using System;
using UnityEngine;

public interface IBuildingFactory
{
    public event Action<GameObject> OnCreateBuilding;
    public GameObject CreateBuilding(Building building);
}