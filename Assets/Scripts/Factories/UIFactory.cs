using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefasbs/Canvas";
    private const string CreationPanelPath = "UIEllements/UIPrefasbs/CreateionPanel";
    private const string BuildingButtonPath = "UIEllements/UIPrefasbs/BuildingButton";
    private const string PanelOfSelectedPath = "UIEllements/UIPrefasbs/PanelOfSelected";
    private const string ResourceCountPanelPath = "UIEllements/UIPrefasbs/ResourceCountPanel";
    private const string UnitButtonPath = "UIEllements/UIPrefasbs/UnitButton";
    private const string BuildingButtonsRootPath = "UIEllements/UIPrefasbs/BuildingButtonsRoot";
    private const string UnitButtonsRootPath = "UIEllements/UIPrefasbs/UnitButtonsRoot";

    private readonly IUIHandlerFactory _uiHandlerFactory;
    private readonly DiContainer _diContainer;

    private Dictionary<SelectStatusChanger, Transform> _currentSelectIconDictionary =
        new Dictionary<SelectStatusChanger, Transform>();

    private UnitButtonsHandler _unitButtonsHandler;
    private BuildButtonsHandler _buildButtonsHandler;
    private Transform _rootCanvas;
    private Transform _creationPannel;
    private Transform _panelOfSelected;
    private Transform _buildingButtonsRoot;
    private Transform _unitButtonsRoot;
    private Transform _recourceCountPanel;

    public Transform ResourceCountPanel => _recourceCountPanel; 

    public UIFactory(IUIHandlerFactory uiHandlerFactory, DiContainer diContainer)
    {
        _uiHandlerFactory = uiHandlerFactory;
        _diContainer = diContainer;
    }

    public void CreatCanvas()
    {
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        _rootCanvas = Object.Instantiate(rootCanvas);
    }

    public void CreatCreationPanel()
    {
        Transform creationPanel = Resources.Load<GameObject>(CreationPanelPath).transform;
        _creationPannel = Object.Instantiate(creationPanel, _rootCanvas);
    }

    public void CreatePanelOfSelectedObjects()
    {
        Transform panelOfSelected = Resources.Load<Transform>(PanelOfSelectedPath);
        _panelOfSelected = Object.Instantiate(panelOfSelected, _rootCanvas);
    }

    public void CreateResourceCountPanel()
    {
        GameObject recourceCountPanel = _diContainer.InstantiatePrefabResource(ResourceCountPanelPath, _rootCanvas);
        _recourceCountPanel = recourceCountPanel.transform;
    }

    public List<Transform> CreateUnitCreationButtons(List<UnitStaticData> unitList, List<Transform> unitButtonsList,
        Transform building)
    {
        unitButtonsList = new List<Transform>();
        
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

    public List<Transform> CreateBuildingCreationButtons(List<BuildingStaticData> buildingList, List<Transform> buildingButtonsList)
    {
        buildingButtonsList = new List<Transform>();

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

        Transform buildingButtonPrefab = Resources.Load<Transform>(BuildingButtonPath);
        
        Transform buildingButton = Object.Instantiate(buildingButtonPrefab, _buildingButtonsRoot);
        buildingButton.GetChild(0).GetComponent<TMP_Text>().text = building.BuildingName;

        if (_buildButtonsHandler == null)
        {
            _buildButtonsHandler = _uiHandlerFactory.CreateBuildingButtonsHandler(_buildingButtonsRoot);
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

        Transform unitButtonPrefab = Resources.Load<Transform>(UnitButtonPath);

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
            .AddListener(() => { _buildButtonsHandler.CreateBuilding(building); });
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
        Transform buildingButtonsRoot = Resources.Load<Transform>(BuildingButtonsRootPath);
        _buildingButtonsRoot = Object.Instantiate(buildingButtonsRoot, _creationPannel);
        return _buildingButtonsRoot;
    }

    private Transform CreateUnitButtonsRoot()
    {
        Transform unitButtonsRootPrefab = Resources.Load<Transform>(UnitButtonsRootPath);
        _unitButtonsRoot = Object.Instantiate(unitButtonsRootPrefab, _creationPannel);
        return _unitButtonsRoot;
    }
}