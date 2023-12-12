using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Logic.MonoBehaviors.View
{
    public class ResourceCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private IGlobalResourcessStorageService _globalResourcessStorageService;

        [Inject]
        public void Constructor(IGlobalResourcessStorageService globalResourcessStorageService)
        {
            _globalResourcessStorageService = globalResourcessStorageService;
            _globalResourcessStorageService.OnChangeResourceCount += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            _text.text =
                _globalResourcessStorageService.StorageResource.ToString();
        }
    }
}
