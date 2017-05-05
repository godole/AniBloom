using UnityEngine;
using System.Collections;
using System;

public class LopeState : IState {

    PlayerControl m_PlayerControl;

    float m_LopeValue = 0;
    float linelength;
    double m_StartAngle;
    GameObject m_Lope = null;
    Vector2 m_LopeStartPosition;

    public LopeState(PlayerControl pc, Collider2D col)
    {
        m_PlayerControl = pc;
        m_LopeStartPosition = pc.gameObject.transform.localPosition;
        m_Lope = col.gameObject;
        m_StartAngle = m_Lope.transform.parent.gameObject.GetComponent<Rope>().Angle - 180;
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

    public void Jump()
    {
    }

    public void OnTriggerEnter2D(Collider2D col, Collider2D target)
    {
        if (col.transform.tag == "Player" && target.transform.tag == "Obstacle")
            m_PlayerControl.Hit();
    }

    public void OnTriggerExit2D(Collider2D col, Collider2D target)
    {
    }
}
