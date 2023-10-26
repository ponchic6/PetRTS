using UnityEngine;

public class UIFactory
{
    private const string CanvasPath = "UIEllements/Canvas";
    private const string BuildingListPanelPath = "UIEllements/BuilidngListPanel";

    private Transform _rootCanvas;
    public GameObject CreatBuildingListPanel()
    {
        GameObject panel = Resources.Load<GameObject>(BuildingListPanelPath);

        if (_rootCanvas != null)
            return Object.Instantiate(panel, _rootCanvas);
        return null;
    }

    public Transform CreatCanvas()
    {    
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        _rootCanvas = Object.Instantiate(rootCanvas);
        return _rootCanvas;
    }
    
}