using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefasbs/Canvas";
    private const string CreationPanelPath = "UIEllements/UIPrefasbs/CreateionPanel";
    private const string BuildingButtonPath = "UIEllements/UIPrefasbs/BuildingButton";
    private const string PanelOfSelectedPath = "UIEllements/UIPrefasbs/PanelOfSelected";
    private const string UnitButtonPath = "UIEllements/UIPrefasbs/UnitButton";
    private const string BuildingButtonsRootPath = "UIEllements/UIPrefasbs/BuildingButtonsRoot";
    private const string InitialBuildingButtonsConfig = "UIEllements/InitialBuildingButtonsConfig";
    private const string UnitButtonsRootPath = "UIEllements/UIPrefasbs/UnitButtonsRoot";

    private readonly IUIHandlerFactory _uiHandlerFactory;
    
    private Dictionary<ViewSelectStatusChanger, Transform> _currentSelectIconDictionary =
        new Dictionary<ViewSelectStatusChanger, Transform>();

    private UnitButtonsHandler _unitButtonsHandler;
    private BuildButtonsHandler _buildButtonsHandler;
    private Transform _rootCanvas;
    private Transform _creationPannel;
    private Transform _panelOfSelected;
    private Transform _buildingButtonsRoot;
    private Transform _unitButtonsRoot;

    public Transform BuildingButtonsRoot => _buildingButtonsRoot;
    public Transform UnitButtonsRoot => _unitButtonsRoot;
    
    public UIFactory(IUIHandlerFactory uiHandlerFactory)
    {
        _uiHandlerFactory = uiHandlerFactory;
    }

    public Transform CreatCanvas()
    {
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        _rootCanvas = Object.Instantiate(rootCanvas);
        return _rootCanvas;
    }

    public Transform CreatCreationPanel()
    {   
        
        Transform panel = Resources.Load<GameObject>(CreationPanelPath).transform;
        _creationPannel = Object.Instantiate(panel, _rootCanvas);
        return _creationPannel;
    }

    public Transform CreatePanelOfSelectedObjects()
    {
        Transform panelOfSelected = Resources.Load<Transform>(PanelOfSelectedPath);
        _panelOfSelected = Object.Instantiate(panelOfSelected, _rootCanvas);
        return _panelOfSelected;
    }

    public Transform CreateBuildingButton(BuildingConfig buildingConfig)
    {
        if (_buildingButtonsRoot == null)
        {
            _buildingButtonsRoot = CreateBuildingButtonsRoot();
        }

        Transform buildingButtonPrefab = Resources.Load<Transform>(BuildingButtonPath);
        
        Transform buildingButton = Object.Instantiate(buildingButtonPrefab, _buildingButtonsRoot);
        buildingButton.GetChild(0).GetComponent<TMP_Text>().text = buildingConfig.GetBuildName();

        if (_buildButtonsHandler == null)
        {
            _buildButtonsHandler = _uiHandlerFactory.CreateBuildingButtonsHandler(_buildingButtonsRoot);
        }
        
        BindBuildingButton(buildingButton, buildingConfig);
        
        return buildingButton;
    }

    public Transform CreateUnitButton(UnitConfig unit)
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

        BindUnitButton(_unitButtonsHandler, unit, unitButton);

        return unitButton;
    }

    public List<Transform> CreateUnitButtonsForBuilding(List<UnitConfig> unitList, List<Transform> unitButtonsList)
    {
        unitButtonsList = new List<Transform>();

        int i = 0;
        int j = 0;

        foreach (UnitConfig config in unitList)
        {
            Transform button = CreateUnitButton(config);
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

    public void CreateInitialBuildButtons()
    {
        InitialBuildingButtonsConfigSO buildingConfigsSo = Resources.Load<InitialBuildingButtonsConfigSO>(InitialBuildingButtonsConfig);
        
        CreateBuildingButton(buildingConfigsSo.BuildingConfigs[0]);
        CreateBuildingButton(buildingConfigsSo.BuildingConfigs[1]).position += new Vector3(0, -65, 0);
        CreateBuildingButton(buildingConfigsSo.BuildingConfigs[2]).position += new Vector3(0, -65, 0) * 2;
    }

    public Transform CreateIconOnSelectPanel(ViewSelectStatusChanger unit)
    {
        if (_panelOfSelected != null && !_currentSelectIconDictionary.ContainsKey(unit))
        {
            Transform icon = Object.Instantiate(unit.GetSelectionIcon().transform, _panelOfSelected);
            _currentSelectIconDictionary[unit] = icon;
            UpdateSelectIconPos();

            return icon;
        }

        return null;
    }

    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit)
    {
        if (_currentSelectIconDictionary.ContainsKey(unit))
        {
            Object.Destroy(_currentSelectIconDictionary[unit].gameObject);
            _currentSelectIconDictionary.Remove(unit);
        }

        UpdateSelectIconPos();
    }

    private void UpdateSelectIconPos()
    {
        int i = 0;

        foreach (Transform _currentIcon in _currentSelectIconDictionary.Values)
        {
            _currentIcon.localPosition = new Vector3(-200, 50, 0) + new Vector3(100, 0, 0) * i;
            i++;
        }
    }

    private void BindBuildingButton(Transform buildButton, BuildingConfig buildingConfig)
    {
        switch (buildingConfig.Type)
        {
            case BuildingType.Castle:
                buildButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { _buildButtonsHandler.CreateCastle(); });
                break;
            case BuildingType.Tower:
                buildButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { _buildButtonsHandler.CreateTower(); });
                break;
            case BuildingType.MagicSchool:
                buildButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { _buildButtonsHandler.CreateMagicSchool(); });
                break;
        }
    }

    private void BindUnitButton(UnitButtonsHandler unitButtonsHandler, UnitConfig unit, Transform unitButton)
    {
        switch (unit.Type)
        {
            case WarriorType.Knight:
                unitButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { unitButtonsHandler.CreateKnight(); });
                break;
            case WarriorType.Bower:
                unitButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { unitButtonsHandler.CreateBower(); });
                break;

            case WarriorType.Wizard:
                unitButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { unitButtonsHandler.CreateWizard(); });
                break;
        }
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