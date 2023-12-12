using System;

namespace Services
{
    public interface IGlobalResourcessStorageService
    {
        public event Action OnChangeResourceCount;
        public float StorageResource { get; }
        public void AddResource(float resourceCount);
        public void RemoveResource(float resourceCount);
    }
}