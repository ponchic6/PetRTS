using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/Canvas";
    private const string BuildingListPanelPath = "UIEllements/BuilidngListPanel";
    private const string BuildbuttonsPath = "UIEllements/BuildButtons";

    private readonly DiContainer _diContainer;
    private readonly IUIHandlerFactory _uiHandlerFactory;
    
    private Transform _rootCanvas;
    private Transform _buildingPannel;
    private Transform _buildingButtons;

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

            BuildingButtonsHandler buildingButtonsHandler =
                _uiHandlerFactory.CreateBuildingButtonsHandler(_buildingPannel);

            BindBuildingButtons(buildingButtonsHandler);

            return _buildingButtons;
        }
        
        return null;
    }

    private void BindBuildingButtons(BuildingButtonsHandler buildingButtonsHandler)
    {
        _buildingButtons.GetChild(0).gameObject.GetComponent<Button>().
            onClick.AddListener(() => { buildingButtonsHandler.CreateBuilding(1); });
            
        _buildingButtons.GetChild(1).gameObject.GetComponent<Button>().
            onClick.AddListener(() => { buildingButtonsHandler.CreateBuilding(2); });

        _buildingButtons.GetChild(2).gameObject.GetComponent<Button>().
            onClick.AddListener(() => { buildingButtonsHandler.CreateBuilding(3); });

    }
}