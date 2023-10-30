﻿using UnityEngine;
using Zenject;

public class BuildingButtonsHandler : MonoBehaviour
{
    private IBuildingService _buildingService;
    
    [Inject]
    public void Constructor(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    public void CreateBuilding()
    {
        _buildingService.CreateBuilding();
    }
}