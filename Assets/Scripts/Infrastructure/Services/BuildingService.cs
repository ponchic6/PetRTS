using System;
using UnityEngine;

public class BuildingService : IBuildingService
{
    private readonly IBuildingFactory _buildingFactory;
    private readonly IInputService _inputService;
    private readonly ITickService _tickService;
    
    private GameObject _currentBuilding;
    private Camera _camera;
    
    public BuildingService(IBuildingFactory buildingFactory, IInputService inputService, ITickService tickService)
    {
        _inputService = inputService;
        _inputService.OnLeftClick += SetupCurrentBuilding;
        
        _buildingFactory = buildingFactory;
        
        _tickService = tickService;
        _tickService.OnTick += SetCurrentBuildingPosToCursor;
    }

    public void CreateBuilding()
    {
        _currentBuilding = _buildingFactory.CreateBuilding1();
    }

    private void SetCurrentBuildingPosToCursor()
    {
        if (_currentBuilding != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
            
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, 1 << 6))
            {
                _currentBuilding.transform.position = raycastHit.point;
            }
        }
    }

    private void SetupCurrentBuilding()
    {
        if (_currentBuilding != null)
            _currentBuilding = null;
    }
}