using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class RunningState : IState{

    PlayerControl m_PlayerControl;
    Collider2D _CurSlideCol;

    public RunningState(PlayerControl pc, Collider2D col)
    {
        m_PlayerControl = pc;
        m_PlayerControl.GravityValue = 0.0f;
        m_PlayerControl.JumpCount = 1;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Run);
        m_PlayerControl.StepGround(col.gameObject.GetComponent<IStepable>());

        _CurSlideCol = col;
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

            else if (target.transform.tag == "Ground" ||
                target.transform.tag == "Platform")
                m_PlayerControl.ChangeState(new RunningState(m_PlayerControl, target));

            else if (target.transform.tag == "Slide")
                m_PlayerControl.ChangeState(new SlideState(m_PlayerControl, target));

            else if (target.transform.tag == "Rope")
                m_PlayerControl.ChangeState(new LopeState(m_PlayerControl, target));
        }
    }

    public void OnTriggerExit2D(Collider2D col, Collider2D target)
    {
        if(_CurSlideCol.Equals(target))
            m_PlayerControl.ChangeState(new AirState(m_PlayerControl));
    }

    public void SlideEnd()
    {
    }

    public void Hit()
    {
        SceneManager.LoadScene("Test");
    }
}
