using System;

public class ResourceJobProgressData : JobProgressData
{
    private void Awake()
    {
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