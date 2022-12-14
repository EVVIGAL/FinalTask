using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _range;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _range)
        {
            NeedTransit = true;
        }
    }
}
