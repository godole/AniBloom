using UnityEngine;
using System.Collections;
using System;

public class RunningState : IState{

    PlayerControl m_PlayerControl;

    public RunningState(PlayerControl pc, Collider2D col)
    {
        m_PlayerControl = pc;
        m_PlayerControl.GravityValue = 0.0f;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Run);
        m_PlayerControl.StepGround(col.gameObject.GetComponent<IStepable>());
    }

    public void StateUpdate()
    {

    }

    public void Jump()
    {
        m_PlayerControl.Jump(true);
    }

    public void OnTriggerEnter2D(Collider2D col, Collider2D target)
    {
        if (col.transform.tag == "Player")
        {
            if (target.transform.tag == "Obstacle")
                m_PlayerControl.Hit();

            else if (target.transform.tag == "DoubleJump")
                m_PlayerControl.JumpCount++;

            else if (target.transform.tag == "Fever")
                m_PlayerControl.ChangeState(new FeverState(m_PlayerControl));

            else if (target.transform.tag == "Ground")
                m_PlayerControl.GroundCollisionEnter(target);

            else if (target.transform.tag == "Slide")
                m_PlayerControl.SlideCollisionEnter(target);

            else if (target.transform.tag == "Rope")
                m_PlayerControl.ChangeState(new LopeState(m_PlayerControl, target));
        }
    }

    public void OnTriggerExit2D(Collider2D col, Collider2D target)
    {
        m_PlayerControl.CollisionExit();
    }
}
