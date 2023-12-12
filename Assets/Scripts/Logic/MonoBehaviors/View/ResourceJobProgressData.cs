namespace Logic.MonoBehaviors.View
{
    public class ResourceJobProgressData : JobProgressData
    {
        protected override void Awake()
        {   
            base.Awake();
            _currentProgress = _maxProgress;
        }

        public override void UpdateProgress(float delta)
        {
            if (_currentProgress - delta > 0)
            {
                _currentProgress -= delta;
            }
        
            else
            {
                _currentProgress = 0;
                HasObjectJob = false;
                InvokeOnFinishedWorking();
            }

        }
    }
}