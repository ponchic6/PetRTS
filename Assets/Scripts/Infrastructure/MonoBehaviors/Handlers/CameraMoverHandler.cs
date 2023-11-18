using UnityEngine;
using Zenject;

public class CameraMoverHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;

    private ICameraMoverService _cameraMoverService;

    [Inject]
    public void Constructor(ICameraMoverService cameraMoverService)
    {
        _cameraMoverService = cameraMoverService;
        _cameraMoverService.OnReachCursorScreenBoundary += MoveCameraOnReachBoundaryCursor;
        _cameraMoverService.OnChangeCursorPosWithHoldDownMiddleButton += MoveCameraOnMidleButtonHold;
    }

    private void MoveCameraOnReachBoundaryCursor(Vector3 direction)
    {
        _camera.transform.position += direction * _speed * Time.deltaTime;
    }

    private void MoveCameraOnMidleButtonHold(Vector3 radiusVector)
    {
        transform.position += radiusVector * 0.01f;
    }
}