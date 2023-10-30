using System;
using UnityEngine;
using Zenject;

public class BuildingService
{
    private readonly BuildingFactory _buildingFactory;
    private readonly IInputService _inputService;
    private GameObject _currentBuilding;
    private Camera _camera;
    
    public BuildingService(BuildingFactory buildingFactory, IInputService inputService)
    {
        _inputService = inputService;
        _buildingFactory = buildingFactory;
        
        _camera = Camera.main;
    }

    public void CreateBuilding()
    {
        _currentBuilding = _buildingFactory.CreateBuilding();
        _currentBuilding.transform.position =
                _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}