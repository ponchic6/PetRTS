using System;
using UnityEngine;

public interface IBuildingFactory
{
    public event Action<GameObject> OnCreateBuilding; 
    public GameObject CreateCastle();
    public GameObject CreateTower();
    public GameObject CreateMagicSchool();
}