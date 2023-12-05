using System;

public class ResourceProgressData : ProgressData
{
    private void Awake()
    {
        _currentProgress = _maxProgress;
    }

    public override void UpdateProgress(float delta)
    {
        if (_currentProgress - delta > 0)
        {   
            InvokeOnChangeProgress(delta);
            _currentProgress -= delta;
        }
        
        else
        {   
            InvokeOnChangeProgress(_currentProgress);
            _currentProgress = 0;
            HasObjectJob = false;
            InvokeOnFinishedWorking();
        }

    }
}