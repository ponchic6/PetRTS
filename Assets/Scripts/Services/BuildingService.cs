﻿using Factories;
using Logic.MonoBehaviors.View;
using UnityEngine;

namespace Services
{
    public class BuildingService
    {
        private readonly IBuildingFactory _buildingFactory;
        private readonly IInputService _inputService;
        private readonly ITickService _tickService;

        private GameObject _currentBuilding;
        private Camera _camera;

        public BuildingService(IInputService inputService, ITickService tickService, IBuildingFactory buildingFactory)
        {
            _inputService = inputService;
            _inputService.OnLeftClickDown += SetupBuildingFromCursor;

            _buildingFactory = buildingFactory;
            _buildingFactory.OnCreatedBuilding += SetCreatedBuilding;

            _tickService = tickService;
            _tickService.OnTick += SetCurrentBuildingPosToCursor;
        }

        private void SetCreatedBuilding(GameObject building)
        {
            _currentBuilding = building;
        }

        private void SetCurrentBuildingPosToCursor()
        {
            if (_currentBuilding != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());

                if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, 1 << 6))
                    _currentBuilding.transform.position = raycastHit.point;
            }
        }

        private void SetupBuildingFromCursor()
        {
            if (_currentBuilding != null)
            {   
                _currentBuilding.GetComponent<BuildingColiderActivator>().ActiveCollider();
                _currentBuilding = null;
            }
        }
    }
}