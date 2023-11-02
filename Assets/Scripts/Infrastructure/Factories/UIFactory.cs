using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefasbs/Canvas";
    private const string BuildingListPanelPath = "UIEllements/UIPrefasbs/BuilidngListPanel";
    private const string BuildbuttonsPath = "UIEllements/UIPrefasbs/BuildButtons";
    private const string PanelOfSelectedPath = "UIEllements/UIPrefasbs/PanelOfSelected";

    private readonly DiContainer _diContainer;
    private readonly IUIHandlerFactory _uiHandlerFactory;
    
    private Transform _rootCanvas;
    private Transform _buildingPannel;
    private Transform _buildingButtons;
    private Transform _panelOfSelected;

    public UIFactory(DiContainer diContainer, IUIHandlerFactory uiHandlerFactory)
    {
        _diContainer = diContainer;
        _uiHandlerFactory = uiHandlerFactory;
    }

    public Transform CreatCanvas()
    {    
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        _rootCanvas = Object.Instantiate(rootCanvas);
        return _rootCanvas;
    }

    public Transform CreatBuildingListPanel()
    {
        if (_rootCanvas != null)
        {
            Transform panel = Resources.Load<GameObject>(BuildingListPanelPath).transform;
            _buildingPannel = Object.Instantiate(panel, _rootCanvas);
            return _buildingPannel;
        }

        return null;
    }

    public Transform CreateBuildButtons()
    {
        if (_buildingPannel != null)
        {
            Transform buildingButtons = Resources.Load<Transform>(BuildbuttonsPath);
            _buildingButtons = Object.Instantiate(buildingButtons, _buildingPannel);

            BuildButtonsHandler buildButtonsHandler =
                _uiHandlerFactory.CreateBuildingButtonsHandler(_buildingPannel);

            BindBuildingButtons(buildButtonsHandler);

            return _buildingButtons;
        }
        
        return null;
    }

    public Transform CreatePanelOfSelectedObjects()
    {
        if (_rootCanvas != null)
        {
            Transform panelOfSelected = Resources.Load<Transform>(PanelOfSelectedPath);
            _panelOfSelected = Object.Instantiate(panelOfSelected, _rootCanvas);
            return _panelOfSelected;
        }

        return null;
    }

    private void BindBuildingButtons(BuildButtonsHandler buildButtonsHandler)
    {
        _buildingButtons.GetChild(0).gameObject.GetComponent<Button>().
            onClick.AddListener(() => { buildButtonsHandler.CreateBuilding(1); });
            
        _buildingButtons.GetChild(1).gameObject.GetComponent<Button>().
            onClick.AddListener(() => { buildButtonsHandler.CreateBuilding(2); });

        _buildingButtons.GetChild(2).gameObject.GetComponent<Button>().
            onClick.AddListener(() => { buildButtonsHandler.CreateBuilding(3); });

    }
}