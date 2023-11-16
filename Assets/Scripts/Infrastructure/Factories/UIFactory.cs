using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefasbs/Canvas";
    private const string CreationPanelPath = "UIEllements/UIPrefasbs/CreateionPanel";
    private const string BuildButtonsPath = "UIEllements/UIPrefasbs/BuildButtons";
    private const string PanelOfSelectedPath = "UIEllements/UIPrefasbs/PanelOfSelected";
    private const string UnitButtonPath = "UIEllements/UIPrefasbs/UnitButton";

    private readonly IUIHandlerFactory _uiHandlerFactory;

    private Dictionary<ViewSelectStatusChanger, Transform> _unitSelectIconDictionary = new Dictionary<ViewSelectStatusChanger, Transform>();
    private UnitButtonsHandler _unitButtonsHandler;
    public Transform RootCanvas { get; private set; }
    public Transform CreationPannel { get; private set; }
    public Transform BuildingButtons { get; private set; }
    public Transform PanelOfSelected { get; private set; }

    public UIFactory(IUIHandlerFactory uiHandlerFactory)
    {
        _uiHandlerFactory = uiHandlerFactory;
    }

    public Transform CreatCanvas()
    {
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        RootCanvas = Object.Instantiate(rootCanvas);
        return RootCanvas;
    }

    public Transform CreatBuildingListPanel()
    {
        if (RootCanvas != null)
        {
            Transform panel = Resources.Load<GameObject>(CreationPanelPath).transform;
            CreationPannel = Object.Instantiate(panel, RootCanvas);
            return CreationPannel;
        }

        return null;
    }

    public Transform CreateBuildButtons()
    {
        if (CreationPannel != null)
        {
            Transform buildingButtons = Resources.Load<Transform>(BuildButtonsPath);
            BuildingButtons = Object.Instantiate(buildingButtons, CreationPannel);

            BuildButtonsHandler buildButtonsHandler =
                _uiHandlerFactory.CreateBuildingButtonsHandler(CreationPannel);

            BindBuildingButtons(buildButtonsHandler);

            return BuildingButtons;
        }

        return null;
    }

    public Transform CreateUnitButton(UnitConfig unit)
    {   
        
        if (CreationPannel != null)
        {
            Transform unitButtonPrefab = Resources.Load<Transform>(UnitButtonPath);
            
            Transform unitButton = Object.Instantiate(unitButtonPrefab, CreationPannel);
            unitButton.GetComponent<Image>().sprite = unit.CreationIcon;
            
            if (_unitButtonsHandler == null)
                _unitButtonsHandler = _uiHandlerFactory.CreateUnitButtonsHandler(CreationPannel);

            BindUnitButton(_unitButtonsHandler, unit, unitButton);

            return unitButton;
        }

        return null;

    }

    public Transform CreatePanelOfSelectedObjects()
    {
        if (RootCanvas != null)
        {
            Transform panelOfSelected = Resources.Load<Transform>(PanelOfSelectedPath);
            PanelOfSelected = Object.Instantiate(panelOfSelected, RootCanvas);
            return PanelOfSelected;
        }

        return null;
    }

    public Transform CreateIconOnSelectPanel(ViewSelectStatusChanger unit)
    {
        if (PanelOfSelected != null && !_unitSelectIconDictionary.ContainsKey(unit))
        {
            Transform icon = Object.Instantiate(unit.GetIcon().transform, PanelOfSelected);
            _unitSelectIconDictionary[unit] = icon;
            UpdateIconPos();

            return icon;
        }

        return null;
    }

    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit)
    {
        if (_unitSelectIconDictionary.ContainsKey(unit))
        {
            Object.Destroy(_unitSelectIconDictionary[unit].gameObject);
            _unitSelectIconDictionary.Remove(unit);
        }

        UpdateIconPos();
    }

    private void UpdateIconPos()
    {
        int i = 0;

        foreach (Transform _currentIcon in _unitSelectIconDictionary.Values)
        {
            _currentIcon.localPosition = new Vector3(-200, 50, 0) + new Vector3(100, 0, 0) * i;
            i++;
        }
    }

    private void BindUnitButton(UnitButtonsHandler unitButtonsHandler, UnitConfig unit, Transform UnitButton)
    {
        switch (unit.Type)
        {
            case WarriorType.Knight:
                UnitButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { unitButtonsHandler.CreateKnight(); });
                break;
            case WarriorType.Bower:
                UnitButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { unitButtonsHandler.CreateBower(); });
                break;
            
            case WarriorType.Wizard:
                UnitButton
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => { unitButtonsHandler.CreateWizard(); });
                break;
        }
    }

    private void BindBuildingButtons(BuildButtonsHandler buildButtonsHandler)
    {
        BuildingButtons.GetChild(0).gameObject.GetComponent<Button>().onClick
            .AddListener(() => { buildButtonsHandler.CreateBuilding(1); });

        BuildingButtons.GetChild(1).gameObject.GetComponent<Button>().onClick
            .AddListener(() => { buildButtonsHandler.CreateBuilding(2); });

        BuildingButtons.GetChild(2).gameObject.GetComponent<Button>().onClick
            .AddListener(() => { buildButtonsHandler.CreateBuilding(3); });
    }
}