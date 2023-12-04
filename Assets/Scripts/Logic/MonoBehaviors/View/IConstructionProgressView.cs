﻿using UnityEngine;

public interface IConstructionProgressView
{
    public void IncreaseBuildingProgress(float delta);
    public Transform GetTransform();
    public bool IsBuilded { get; }
}