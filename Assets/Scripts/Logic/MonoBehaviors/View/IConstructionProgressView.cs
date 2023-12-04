using System;
using UnityEngine;

public interface IConstructionProgressView
{
    public event Action OnBuilded;
    public void IncreaseBuildingProgress(float delta);
    public Transform GetTransform();
    public bool IsBuilded { get; }
}