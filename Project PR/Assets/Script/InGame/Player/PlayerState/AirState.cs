using UnityEngine;
using System.Collections;
using System;

public class AirState : IState {

    PlayerControl m_PlayerControl;

    public AirState(PlayerControl pc)
    {
        m_PlayerControl = pc;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Jump);
    }

    public void StateUpdate()
    {
        m_PlayerControl.MoveVector = new Vector2(m_PlayerControl.MoveVector.x, m_PlayerControl.GravityValue);
        m_PlayerControl.GravityValue -= m_PlayerControl.GravityScale * Time.deltaTime;

        if (m_PlayerControl.gameObject.transform.localPosition.y > 1200)
            m_PlayerControl.gameObject.transform.localPosition = new Vector3(m_PlayerControl.gameObject.transform.localPosition.x, 600, m_PlayerControl.gameObject.transform.localPosition.z);
    }

    public void Jump()
    {
        m_PlayerControl.Jump(false);
    }

    public void OnTriggerEnter2D(Collider2D col, Collider2D target)
    {
        if(col.transform.tag == "Player")
        {
            if (target.transform.tag == "Obstacle")
                m_PlayerControl.Hit();

            else if (target.transform.tag == "DoubleJump")
                m_PlayerControl.JumpCount++;

            else if (target.transform.tag == "Fever")
                m_PlayerControl.ChangeState(new FeverState(m_PlayerControl));

            else if (target.transform.tag == "Ground" ||
                target.transform.tag == "Platform")
                m_PlayerControl.ChangeState(new RunningState(m_PlayerControl, target));

            else if (target.transform.tag == "Slide" ||
                target.transform.tag == "SlideCheck")
                m_PlayerControl.ChangeState(new SlideState(m_PlayerControl, target));

            else if (target.transform.tag == "Rope")
                m_PlayerControl.ChangeState(new LopeState(m_PlayerControl, target));
        }
    }

    public void OnTriggerExit2D(Collider2D col, Collider2D target)
    {
        
    }
}
