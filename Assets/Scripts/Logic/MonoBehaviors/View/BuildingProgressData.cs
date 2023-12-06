﻿using System;

public class BuildingProgressData : ProgressData
{
    private void Awake()
    {
        _currentProgress = 0;
    }

    public override void UpdateProgress(float delta)
    {
        if (_currentProgress + delta < _maxProgress)
        {
            _currentProgress += delta;
        }
        
        else
        {
            _currentProgress = _maxProgress;
            HasObjectJob = false;
            InvokeOnFinishedWorking();
        }
    }
}