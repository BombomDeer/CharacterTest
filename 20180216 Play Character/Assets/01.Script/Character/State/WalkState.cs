using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    override public void Start()
    {
        //Vector3 wayPoint = _character.GetWayPoint(0);
        //_character.SetDestination(wayPoint);

        _character.PlayAnimation("walk", null);
        _character.StartWalk(2.0f);
    }
}
