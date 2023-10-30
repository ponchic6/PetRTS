using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIFactory
{
    private const string CanvasPath = "UIEllements/Canvas";
    private const string BuildingListPanelPath = "UIEllements/BuilidngListPanel";
    private const string BuildbuttonsPath = "UIEllements/BuildButtons";
    private const string BuildingButtonsHandlerPath = "UIEllements/UIHandlers/BuildingButtonsHandler";

    private readonly DiContainer _diContainer;
    private Transform _rootCanvas;
    private Transform _buildingPannel;
    private Transform _buildingButtons;

    public UIFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public Transform CreatCanvas()
    {    
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        _rootCanvas = Object.Instantiate(rootCanvas);
        return _rootCanvas;
    }

    public GameObject CreatBuildingListPanel()
    {
        GameObject panel = Resources.Load<GameObject>(BuildingListPanelPath);
        _buildingPannel = panel.transform;
        
        if (_rootCanvas != null)
            return Object.Instantiate(panel, _rootCanvas);
        return null;
    }

    public GameObject CreateBuildButtons()
    {
        if (_buildingPannel != null)
        {
            GameObject buildButtons = Object.Instantiate(Resources.Load<GameObject>(BuildbuttonsPath), _rootCanvas);
            GameObject buildingButtonsHandler 
                = _diContainer.InstantiatePrefabResource(BuildingButtonsHandlerPath);

            foreach (Transform button in buildButtons.transform)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(buildingButtonsHandler.GetComponent<BuildingButtonsHandler>().CreateBuilding); 
            }
            _buildingButtons = buildButtons.transform;
        }
        return null;
    }
}