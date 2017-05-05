using UnityEngine;
using System.Collections;

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

    public void OnCollisionEnter2D(Collision2D col)
    {
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Obstacle")
            m_PlayerControl.Hit();

        else if(col.transform.tag == "DoubleJump")
        {
            m_PlayerControl.JumpCount++;
        }
    }

    public void Jump()
    {
        m_PlayerControl.Jump(false);
    }

    public void GroundCollision(Collider2D col)
    {
        m_PlayerControl.ChangeState(new RunningState(m_PlayerControl, col));
    }

    public void GroundCollisionExit(Collider2D col)
    {
    }

    public void SlideCollision(Collider2D col)
    {
        m_PlayerControl.ChangeState(new SlideState(m_PlayerControl, col));
    }

    public void SlideCollisionExit(Collider2D col)
    {
    }
}
