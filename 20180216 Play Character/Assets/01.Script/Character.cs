using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] AnimationController _animationController;
    // Start is called before the first frame update
    void Start()
    {
        //IdleState _idleState = new IdleState();
        //WaitState _waitState = new WaitState();
        //KickState _kickState = new KickState();

        _stateDic.Add(eState.IDLE, new IdleState());
        _stateDic.Add(eState.WAIT, new WaitState());
        _stateDic.Add(eState.KICK, new KickState());

        for(int i = 0; i<_stateDic.Count;i++)
        {
            eState state = (eState)i;
            _stateDic[state].SetCharacter(this);
        }

        //_idleState.SetCharacter(this);
        //_waitState.SetCharacter(this);
        //_kickState.SetCharacter(this);

        ChangeState(eState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    public enum eState
    {
        IDLE,
        WAIT,
        KICK, 
    }

    public void ChangeState(eState state)
    {
        _state = _stateDic[state];
        _state.Start();
        //switch (state)
        //{
        //    case eState.IDLE:
        //        //IdleStart();
        //        _state = _idleState;
        //        break;
        //    case eState.WAIT:
        //        //WaitStart();
        //        _state = _waitState;
        //        break;
        //    case eState.KICK:
        //        _state = _kickState;
        //        break;
        //}
        //_state.Start();
    }

    void UpdateState()
    {
        _state.Update();
    }

    Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();

    State _state = null;
    
    //void IdleStart()
    //{
    //    _idleState.Start();
    //    //_animationController.Play("idle1", () => 
    //    //{
    //    //    ChangeState(eState.WAIT);
    //    //    //WaitState();
    //    //});

    //}

    //void WaitStart()
    //{
    //    _animationController.Play("idle2", () => 
    //    {
    //        ChangeState(eState.WAIT2);
    //        //KickState();
    //    });
    //}
    


    //void KickStart()
    //{
    //    _animationController.Play("idle5", () => 
    //    {
    //        ChangeState(eState.IDLE);
    //        //IdleState();
    //    });
    //}

    public void PlayAnimation(string trigger, System.Action endCallback)
    {
        _animationController.Play(trigger, endCallback);
    }
}
