using UnityEngine;
using System.Collections;
using System;

public class SlideState : IState {

    PlayerControl m_PlayerControl;

    public SlideState(PlayerControl pc, Collider2D col)
    {
        m_PlayerControl = pc;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Slide);
        m_PlayerControl.StepGround(col.gameObject.GetComponent<IStepable>());

        RectTransform tr = pc.gameObject.GetComponent<RectTransform>();

        if(tr.position.y - tr.rect.height * 100 / 2 < col.gameObject.GetComponent<SlideLine>().EndPosition.y)
            pc.gameObject.transform.rotation = col.gameObject.transform.rotation;
    }

    public void StateUpdate()
    {

    }

    public void Jump()
    {
        m_PlayerControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        m_PlayerControl.Jump(true);
    }

    public void OnTriggerEnter2D(Collider2D col, Collider2D target)
    {
        if (col.transform.tag == "Player")
        {
            if (target.transform.tag == "Obstacle")
                m_PlayerControl.Hit();

            else if (target.transform.tag == "Ground")
                m_PlayerControl.CollisionCount++;

            else if (target.transform.tag == "Slide")
                m_PlayerControl.SlideCollisionEnter(target);
        }
    }

    public void OnTriggerExit2D(Collider2D col, Collider2D target)
    {
        if(col.transform.tag == "Player")
        {
            if(target.transform.tag == "Slide")
            {
                m_PlayerControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
            }
            m_PlayerControl.CollisionExit();
        }
    }
}
