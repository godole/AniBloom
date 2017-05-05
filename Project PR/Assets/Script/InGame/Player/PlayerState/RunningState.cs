using UnityEngine;
using System.Collections;

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

    public void OnCollisionEnter2D(Collision2D col)
    {
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Obstacle")
            m_PlayerControl.Hit();

        else if (col.transform.tag == "DoubleJump")
        {
            m_PlayerControl.JumpCount++;
        }
    }

    public void Jump()
    {
        m_PlayerControl.Jump(true);
    }

    public void GroundCollision(Collider2D col)
    {
        m_PlayerControl.ChangeState(new RunningState(m_PlayerControl, col));
    }

    public void GroundCollisionExit(Collider2D col)
    {
        m_PlayerControl.ChangeState(new AirState(m_PlayerControl));
    }

    public void SlideCollision(Collider2D col)
    {
        m_PlayerControl.ChangeState(new SlideState(m_PlayerControl, col));
    }

    public void SlideCollisionExit(Collider2D col)
    {
    }
}
