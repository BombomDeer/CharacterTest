using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] AnimationController _animationController;
    // Start is called before the first frame update

    void Awake()//it's like start but done before Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        //IdleState _idleState = new IdleState();
        //WaitState _waitState = new WaitState();
        //KickState _kickState = new KickState();

        _stateDic.Add(eState.IDLE, new IdleState());
        _stateDic.Add(eState.WAIT, new WaitState());
        _stateDic.Add(eState.KICK, new KickState());
        _stateDic.Add(eState.WALK, new WalkState());

        for (int i = 0; i<_stateDic.Count;i++)
        {
            eState state = (eState)i;
            _stateDic[state].SetCharacter(this);
        }

        //_idleState.SetCharacter(this);
        //_waitState.SetCharacter(this);
        //_kickState.SetCharacter(this);

        ChangeState(eState.WALK);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        UpdateMove();
    }

    public enum eState
    {
        IDLE,
        WAIT,
        KICK, 
        WALK,
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

    //Movement

    CharacterController _characterController;
    float _moveSpeed = 0.0f;
    void UpdateMove()
    {
        //내가 결정한 이동 방향과 속도
        Vector3 moveDirection = Vector3.forward;

        //내가 결정한 이동 방향과 속도에 따른 속도 벡터
        Vector3 moveVelocity = moveDirection*_moveSpeed;

        Vector3 gravityVelocity = Vector3.down * 9.8f;//중력

        //내가 결정한 속도 벡터와 중력 벡터를 고려한 최종속도 벡터
        Vector3 finalVelocity = (moveVelocity + gravityVelocity) * Time.deltaTime;
        _characterController.Move(finalVelocity);
    }

    public void StartWalk(float speed)
    {
        _moveSpeed = speed;
    }
}
