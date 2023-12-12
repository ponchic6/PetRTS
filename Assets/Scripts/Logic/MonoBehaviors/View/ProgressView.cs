using UnityEngine;
using UnityEngine.UI;

namespace Logic.MonoBehaviors.View
{
    public class ProgressView : MonoBehaviour
    {
        [SerializeField] private JobProgressData _jobProgressData;
        [SerializeField] private Image _progressBar;
        private void Update()
        {   
            ShowConstructionProgress();
        }
    
        private void ShowConstructionProgress()
        {
            _progressBar.fillAmount = _jobProgressData.CurrentProgress / _jobProgressData.MaxProgress;
        }
    }
}