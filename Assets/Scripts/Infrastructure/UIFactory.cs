using UnityEngine;

public class UIFactory
{
    private const string CanvasPath = "Canvas"; 
        
    // public GameObject CreatBuildingListPanel()
    // {
    //     
    // }

    public GameObject CreatCanvas()
    {
        GameObject canvas = Resources.Load<GameObject>(CanvasPath);
        return Object.Instantiate(canvas);
    }
}