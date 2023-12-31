﻿using Services;
using UnityEngine;
using Zenject;

namespace Logic.MonoBehaviors.Handlers
{
    public class ResourceCollector : MonoBehaviour
    {
        private IGlobalResourcessStorageService _globalResourcessStorageService;

        [Inject]
        public void Constructor(IGlobalResourcessStorageService globalResourcessStorageService)
        {
            _globalResourcessStorageService = globalResourcessStorageService;
        }
    
        public void AddResource(float currentResourceCount)
        {
            _globalResourcessStorageService.AddResource(currentResourceCount);
        }
    }
}