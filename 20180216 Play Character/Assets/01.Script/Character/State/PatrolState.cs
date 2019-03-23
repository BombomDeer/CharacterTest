using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    Vector3 _prevWayPoint;

    override public void Start()
    {
        //_curIndex++;
        //_curIndex = (_curIndex + 1) % _character.GetWayPointCount();

        //Vector3 wayPoint = _character.GetWayPoint(_curIndex);
        Vector3 wayPoint = _character.GetRandomWayPoint();
        if (wayPoint.Equals(_prevWayPoint))
        {
            _character.ChangeState(Character.eState.WAIT);
        }
        else
        {
            _character.SetDestination(wayPoint);

            _character.ChangeState(Character.eState.WALK);
            _prevWayPoint = wayPoint;
        }
        //_character.PlayAnimation("walk", null);
    }
}
