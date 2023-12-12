using System.Collections.Generic;
using Logic.MonoBehaviors.Handlers;
using Logic.MonoBehaviors.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IUIHandlerFactory _uiHandlerFactory;
        private readonly DiContainer _diContainer;
        private readonly UIStaticData _uiStaticData;

        private Dictionary<SelectStatusChanger, Transform> _currentSelectIconDictionary =
            new Dictionary<SelectStatusChanger, Transform>();

        private UnitButtonsHandler _unitButtonsHandler;
        private BuildingButtonsHandler _buildingButtonsHandler;
        private Transform _rootCanvas;
        private Transform _creationPannel;
        private Transform _panelOfSelected;
        private Transform _buildingButtonsRoot;
        private Transform _unitButtonsRoot;
        private Transform _recourceCountPanel;

        public Transform ResourceCountPanel => _recourceCountPanel; 

        public UIFactory(IUIHandlerFactory uiHandlerFactory, DiContainer diContainer, UIStaticData uiStaticData)
        {
            _uiHandlerFactory = uiHandlerFactory;
            _diContainer = diContainer;
            _uiStaticData = uiStaticData;
        }

        public void CreatCanvas()
        {
            Transform rootCanvas = Resources.Load<GameObject>(_uiStaticData.CanvasPath).transform;
            _rootCanvas = Object.Instantiate(rootCanvas);
        }

        public void CreatCreationPanel()
        {
            Transform creationPanel = Resources.Load<GameObject>(_uiStaticData.CreationPanelPath).transform;
            _creationPannel = Object.Instantiate(creationPanel, _rootCanvas);
        }

        public void CreatePanelOfSelectedObjects()
        {
            Transform panelOfSelected = Resources.Load<Transform>(_uiStaticData.PanelOfSelectedPath);
            _panelOfSelected = Object.Instantiate(panelOfSelected, _rootCanvas);
        }

        public void CreateResourceCountPanel()
        {
            GameObject recourceCountPanel = _diContainer.InstantiatePrefabResource(_uiStaticData.ResourceCountPanelPath, _rootCanvas);
            _recourceCountPanel = recourceCountPanel.transform;
        }

        public List<Transform> CreateUnitCreationButtonsOfBuilding(List<UnitStaticData> unitList, Transform building)
        {
            List<Transform> unitButtonsList = new List<Transform>();
        
            int i = 0;
            int j = 0;

            foreach (UnitStaticData config in unitList)
            {
                Transform button = CreateUnitButton(config, building);
                button.position += new Vector3(0, -65, 0) * i + new Vector3(150, 0, 0) * j;
                unitButtonsList.Add(button);
                i++;
                if (i == 3)
                {
                    i = 0;
                    j++;
                }
            }

            return unitButtonsList;
        }

        public List<Transform> CreateBuildingCreationButtonsOfUnit(List<BuildingStaticData> buildingList)
        {
            List<Transform> buildingButtonsList = new List<Transform>();

            int i = 0;
            int j = 0;

            foreach (BuildingStaticData building in buildingList)
            {
                Transform button = CreateBuildingButton(building);
                button.position += new Vector3(0, -65, 0) * i + new Vector3(150, 0, 0) * j;
                buildingButtonsList.Add(button);
                i++;
                if (i == 3)
                {
                    i = 0;
                    j++;
                }
            }

            return buildingButtonsList;
        }
    
        public void CreateIconOnSelectPanel(SelectStatusChanger unit)
        {
            if (_panelOfSelected != null && !_currentSelectIconDictionary.ContainsKey(unit))
            {
                Transform icon = Object.Instantiate(unit.GetSelectionIcon().transform, _panelOfSelected);
                _currentSelectIconDictionary[unit] = icon;
                UpdateSelectIconPos();
            }
        }

        public void DestroyIconOnSelectPanel(SelectStatusChanger unit)
        {
            if (_currentSelectIconDictionary.ContainsKey(unit))
            {
                Object.Destroy(_currentSelectIconDictionary[unit].gameObject);
                _currentSelectIconDictionary.Remove(unit);
            }

            UpdateSelectIconPos();
        }

        private Transform CreateBuildingButton(BuildingStaticData building)
        {
            if (_buildingButtonsRoot == null)
            {
                _buildingButtonsRoot = CreateBuildingButtonsRoot();
            }

            Transform buildingButtonPrefab = Resources.Load<Transform>(_uiStaticData.BuildingButtonPath);
        
            Transform buildingButton = Object.Instantiate(buildingButtonPrefab, _buildingButtonsRoot);
            buildingButton.GetChild(0).GetComponent<TMP_Text>().text = building.BuildingName;

            if (_buildingButtonsHandler == null)
            {
                _buildingButtonsHandler = _uiHandlerFactory.CreateBuildingButtonsHandler(_buildingButtonsRoot);
            }
        
            BindBuildingButton(buildingButton, building);
        
            return buildingButton;
        }

        private Transform CreateUnitButton(UnitStaticData unit, Transform building)
        {
            if (_unitButtonsRoot == null)
            {
                _unitButtonsRoot = CreateUnitButtonsRoot();
            }

            Transform unitButtonPrefab = Resources.Load<Transform>(_uiStaticData.UnitButtonPath);

            Transform unitButton = Object.Instantiate(unitButtonPrefab, _unitButtonsRoot);
            unitButton.GetComponent<Image>().sprite = unit.CreationIcon;

            if (_unitButtonsHandler == null)
                _unitButtonsHandler = _uiHandlerFactory.CreateUnitButtonsHandler(_unitButtonsRoot);

            BindUnitButton(_unitButtonsHandler, unit, unitButton, building);

            return unitButton;
        }

        private void UpdateSelectIconPos()
        {
            int i = 0;
            int j = 0;
        
            foreach (Transform _currentIcon in _currentSelectIconDictionary.Values)
            {
                _currentIcon.localPosition = new Vector3(-200, 50, 0) + 
                                             new Vector3(100, 0, 0) * i +
                                             new Vector3(0, -100, 0) * j;
                i++;
                if (i == 5)
                {
                    i = 0;
                    j++;
                }
            }
        }

        private void BindBuildingButton(Transform buildButton, BuildingStaticData building)
        {
            buildButton
                .GetComponent<Button>()
                .onClick
                .AddListener(() => { _buildingButtonsHandler.CreateBuilding(building); });
        }

        private void BindUnitButton(UnitButtonsHandler unitButtonsHandler, UnitStaticData unit,
            Transform unitButton, Transform building)
        {
            unitButton
                .GetComponent<Button>()
                .onClick
                .AddListener(() => { unitButtonsHandler.CreateUnit(unit, building); });
        }

        private Transform CreateBuildingButtonsRoot()
        {
            Transform buildingButtonsRoot = Resources.Load<Transform>(_uiStaticData.BuildingButtonsRootPath);
            _buildingButtonsRoot = Object.Instantiate(buildingButtonsRoot, _creationPannel);
            return _buildingButtonsRoot;
        }

        private Transform CreateUnitButtonsRoot()
        {
            Transform unitButtonsRootPrefab = Resources.Load<Transform>(_uiStaticData.UnitButtonsRootPath);
            _unitButtonsRoot = Object.Instantiate(unitButtonsRootPrefab, _creationPannel);
            return _unitButtonsRoot;
        }
    }
}