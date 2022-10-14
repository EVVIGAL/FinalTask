using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTransition : Transition
{
    [SerializeField] private float _timeForRush;

    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeForRush)
        {
            NeedTransit = true;
            _currentTime = 0;
        }
    }
}
