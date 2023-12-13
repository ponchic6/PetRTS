using System;

namespace Services
{
    public class GlobalResourcessStorageService : IGlobalResourcessStorageService
    {
        public event Action OnChangeResourceCount;
    
        private float _storageResource;

        public float StorageResource => _storageResource;

        public GlobalResourcessStorageService()
        {
            AddResource(20);
        }

        public void AddResource(float resourceCount)
        {
            _storageResource += resourceCount;
            OnChangeResourceCount?.Invoke();
        }

        public void RemoveResource(float resourceCount)
        {
            _storageResource -= resourceCount;

            if (_storageResource <= 0)
            {
                _storageResource = 0;
            }
        
            OnChangeResourceCount?.Invoke();
        }
    }
}