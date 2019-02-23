using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] AnimationController _animationController;
    // Start is called before the first frame update
    void Start()
    {
        //IdleState();
        //_animationController.AddEndEvent(()=>
        //{
        //    Debug.Log("Animation Test");
        //});
        ChangeState(eState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    enum eState
    {
        IDLE, WAIT, KICK,
    }

    void ChangeState(eState state)
    {
        switch(state)
        {
            case eState.IDLE:
                IdleState();
                break;
            case eState.WAIT:
                WaitState();
                break;
            case eState.KICK:
                KickState();
                break;
        }
    }


    void IdleState()
    {
        _animationController.Play("idle1", () => { WaitState(); });

    }

    void WaitState()
    {
        _animationController.Play("idle2", () => { KickState(); });
    }

    void KickState()
    {
        _animationController.Play("idle5", () => { IdleState(); });
    }

}
