using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefasbs/Canvas";
    private const string BuildingListPanelPath = "UIEllements/UIPrefasbs/BuilidngListPanel";
    private const string BuildbuttonsPath = "UIEllements/UIPrefasbs/BuildButtons";
    private const string PanelOfSelectedPath = "UIEllements/UIPrefasbs/PanelOfSelected";
    private const string UnitsButtonsPath = "UIEllements/UIPrefasbs/UnitsButtons";

    private readonly IUIHandlerFactory _uiHandlerFactory;

    public Transform RootCanvas { get; private set; }
    public Transform BuildingPannel { get; private set; }
    public Transform BuildingButtons { get; private set; }
    public Transform PanelOfSelected { get; private set; }
    public Transform UnitsButtons { get; private set; }

    private Dictionary<ViewSelectStatusChanger, Transform> _unitIconDictionary = new Dictionary<ViewSelectStatusChanger, Transform>();

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
            Transform panel = Resources.Load<GameObject>(BuildingListPanelPath).transform;
            BuildingPannel = Object.Instantiate(panel, RootCanvas);
            return BuildingPannel;
        }

        return null;
    }

    public Transform CreateBuildButtons()
    {
        if (BuildingPannel != null)
        {
            Transform buildingButtons = Resources.Load<Transform>(BuildbuttonsPath);
            BuildingButtons = Object.Instantiate(buildingButtons, BuildingPannel);

            BuildButtonsHandler buildButtonsHandler =
                _uiHandlerFactory.CreateBuildingButtonsHandler(BuildingPannel);

            BindBuildingButtons(buildButtonsHandler);

            return BuildingButtons;
        }

        return null;
    }

    public Transform CreateUnitsButtons()
    {
        if (BuildingPannel != null)
        {
            Transform unitsButtons = Resources.Load<Transform>(UnitsButtonsPath);
            UnitsButtons = Object.Instantiate(unitsButtons, BuildingPannel);

            UnitButtonsHandler unitButtonsHandler =
                _uiHandlerFactory.CreateUnitButtonsHandler(BuildingPannel);

            BindUnitsButtonHandler(unitButtonsHandler);

            return UnitsButtons;
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
        if (PanelOfSelected != null && !_unitIconDictionary.ContainsKey(unit))
        {
            Transform icon = Object.Instantiate(unit.GetIcon().transform, PanelOfSelected);
            _unitIconDictionary[unit] = icon;
            UpdateIconPos();

            return icon;
        }

        return null;
    }

    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit)
    {
        if (_unitIconDictionary.ContainsKey(unit))
        {
            Object.Destroy(_unitIconDictionary[unit].gameObject);
            _unitIconDictionary.Remove(unit);
        }

        UpdateIconPos();
    }

    private void UpdateIconPos()
    {
        int i = 0;

        foreach (Transform _currentIcon in _unitIconDictionary.Values)
        {
            _currentIcon.localPosition = new Vector3(-200, 50, 0) + new Vector3(100, 0, 0) * i;
            i++;
        }
    }

    private void BindUnitsButtonHandler(UnitButtonsHandler unitButtonsHandler)
    {
        UnitsButtons.GetChild(0).gameObject.GetComponent<Button>().onClick
            .AddListener(() => { unitButtonsHandler.CreateWarrior(); });

        UnitsButtons.GetChild(1).gameObject.GetComponent<Button>().onClick
            .AddListener(() => { unitButtonsHandler.CreateWarrior(); });

        UnitsButtons.GetChild(2).gameObject.GetComponent<Button>().onClick
            .AddListener(() => { unitButtonsHandler.CreateWarrior(); });

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