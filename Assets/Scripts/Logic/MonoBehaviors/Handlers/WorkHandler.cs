using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class WorkHandler : MonoBehaviour
{
    [SerializeField] private float _distanceForWork;
    [SerializeField] private UnitViewSelectStatusChanger _unitViewSelectStatusChanger;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _efficiency;
    private float _currentCooldown;
    private IMoveble _unitMover;
    private IInputService _inputService;
    private IConstructionProgressView _constructionProgressOfCurrentObject;
    
    public bool IsWorking { get; private set; }

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
    }

    private void Update()
    {
        TryWork();
        ReduceCooldown();
    }

    [Inject]
    public void Constructor(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnRightClickDown += TrySendToWorkPoint;
    }

    private void TrySendToWorkPoint()
    {
        if (_unitViewSelectStatusChanger.IsSelect())
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
            
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity) &&
                raycastHit.collider.gameObject.TryGetComponent(out IConstructionProgressView constructionProgressView))
            {
                _constructionProgressOfCurrentObject = constructionProgressView;
                
                Vector3 directionToWorkPoint = (_constructionProgressOfCurrentObject.GetTransform().position -
                                                transform.position).normalized;
                Vector3 destination = _constructionProgressOfCurrentObject.GetTransform().position - 
                                      directionToWorkPoint * (_distanceForWork - 0.1f); 
                
                _unitMover.MoveToDestination(destination);
            }

            else
            {
                _constructionProgressOfCurrentObject = null;
            }
        }
    }

    private void ReduceCooldown()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    private void TryWork()
    {
        if (CanIncreaseBuildingProgress())
        {
            IsWorking = true;

            if (_currentCooldown <= 0)
            {
                _constructionProgressOfCurrentObject.IncreaseBuildingProgress(_efficiency);
                _currentCooldown = _cooldown;
            }
        }

        else
        {
            IsWorking = false;
        }
    }

    private bool CanIncreaseBuildingProgress()
    {
        return _constructionProgressOfCurrentObject != null && 
               Vector3.Distance(transform.position, _constructionProgressOfCurrentObject.GetTransform().position) <= _distanceForWork &&
               !_constructionProgressOfCurrentObject.IsBuilded;
    }
}
