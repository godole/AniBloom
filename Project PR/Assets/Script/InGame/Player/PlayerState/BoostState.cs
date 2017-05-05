using UnityEngine;
using System.Collections;

public class BoostState : IState {

    PlayerControl m_PlayerControl;

    float m_BoostTime;

    public BoostState(PlayerControl pc)
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

    public void OnCollisionEnter2D(Collision2D col)
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Bell":
                m_PlayerControl.ChangeState(new BoostState(m_PlayerControl));
                m_PlayerControl.ObstacleTriggerCheck(col);
                break;
        }
    }

    public void Jump()
    {

    }

    public void GroundCollision(Collider2D col)
    {

    }

    public void GroundCollisionExit(Collider2D col)
    {

    }

    public void SlideCollision(Collider2D col)
    {

    }

    public void SlideCollisionExit(Collider2D col)
    {

    }
}
