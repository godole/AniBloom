using UnityEngine;
using System.Collections;
using System;

public class LopeState : IState {

    PlayerControl m_PlayerControl;

    float m_LopeValue = 0;
    Vector2 m_LopeCollider;
    float linelength;
    double m_StartAngle;
    GameObject m_Lope = null;
    Vector2 m_LopeStartPosition;

    public LopeState(PlayerControl pc, Collider2D col, LopeCheck check)
    {
        m_PlayerControl = pc;
        m_LopeStartPosition = pc.gameObject.transform.localPosition;
        m_Lope = col.gameObject;
        m_StartAngle = m_Lope.transform.parent.gameObject.GetComponent<Rope>().Angle - 180;
        m_LopeCollider = check.gameObject.transform.position;
        linelength = (pc.gameObject.transform.position - m_Lope.gameObject.transform.position).magnitude;
    }

    public void StateUpdate()
    {
        m_LopeValue = m_PlayerControl.gameObject.transform.localPosition.x - m_LopeStartPosition.x;
        float angle = (m_LopeValue / linelength) * Mathf.PI + ((float)m_StartAngle * Mathf.Deg2Rad);
        m_PlayerControl.MoveVector = new Vector2(m_PlayerControl.MaxSpeed, (-Mathf.Sin(angle) * linelength * 0.4f));

        Vector2 velocity = m_PlayerControl.gameObject.transform.position - m_Lope.gameObject.transform.position;
        velocity.Normalize();
        float lopeangle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        m_Lope.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, lopeangle);

        if (lopeangle > -45)
        {
            m_PlayerControl.GravityValue = Mathf.Sin(angle) * linelength * 0.4f;
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

            case "Obstacle":
                m_PlayerControl.Hit();
                break;
        }
    }

    public void Jump()
    {
    }

    public void GroundCollision(Collision2D col)
    {

    }

    public void GroundCollisionExit(Collision2D col)
    {

    }

    public void SlideCollision(Collider2D col)
    {

    }

    public void SlideCollisionExit(Collider2D col)
    {

    }

    public void GroundCollision(Collider2D col)
    {
        m_PlayerControl.ChangeState(new RunningState(m_PlayerControl, col));
    }

    public void GroundCollisionExit(Collider2D col)
    {
        m_PlayerControl.ChangeState(new AirState(m_PlayerControl));
    }
}
