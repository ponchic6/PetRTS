using UnityEngine;

public class ResourceCount : MonoBehaviour
{
    [SerializeField] private int _maxResourceOnUnit;
    private float _currentResourceCount;
    private IWorkHandler _workHandler;
    private void Awake()
    {
        _workHandler = GetComponent<IWorkHandler>();
    }

    private void Update()
    {
        if (_currentResourceCount == _maxResourceOnUnit &&
            _workHandler.GetProgressData() is ResourceProgressData)
        {
            
        }
    }
    
    private void AddResource(float delta)
    {
        if (_currentResourceCount + delta < _maxResourceOnUnit)
        {
            _currentResourceCount += delta;
        }

        else
        {
            _currentResourceCount = _maxResourceOnUnit;
        }
    }

    private void ClearResouce()
    {
        _currentResourceCount = 0;
    }
}
