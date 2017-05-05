using UnityEngine;
using System.Collections;
using System;

public class FeverState : IState {

    PlayerControl m_PlayerControl;

    float m_BoostTime;

    public FeverState(PlayerControl pc)
    {
        m_PlayerControl = pc;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Fever);
        pc.MoveVector = new Vector2(pc.MaxSpeed, 0.0f);
    }

    public void StateUpdate()
    {
        m_BoostTime += Time.deltaTime;

        if (m_BoostTime > 3)
        {
            m_PlayerControl.GravityValue = 0.0f;
            m_PlayerControl.ChangeState(new AirState(m_PlayerControl));
        }
    }

    public void OnTriggerEnter2D(Collider2D col, Collider2D target)
    {
        if (col.transform.tag == "Player" && target.transform.tag == "Fever")
            m_PlayerControl.ChangeState(new FeverState(m_PlayerControl));
    }

    public void OnTriggerExit2D(Collider2D col, Collider2D target)
    {
    }

    public void Jump()
    {
        
    }
}
