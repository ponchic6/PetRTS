using UnityEngine;

namespace Logic.MonoBehaviors.View
{
    public class RotatorBarToCamera : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.back,
                _mainCamera.transform.rotation * Vector3.down);
        }
    }
}
