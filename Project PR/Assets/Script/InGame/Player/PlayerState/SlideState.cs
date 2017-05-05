using UnityEngine;
using System.Collections;

public class SlideState : IState {

    PlayerControl m_PlayerControl;

    public SlideState(PlayerControl pc, Collider2D col)
    {
        m_PlayerControl = pc;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Slide);
        m_PlayerControl.StepGround(col.gameObject.GetComponent<IStepable>());
        pc.gameObject.transform.rotation = col.gameObject.transform.rotation;
    }

    public void StateUpdate()
    {

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
        m_PlayerControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        m_PlayerControl.Jump(true);
    }

    public void GroundCollision(Collider2D col)
    {
        m_PlayerControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        m_PlayerControl.ChangeState(new RunningState(m_PlayerControl, col));
    }

    public void GroundCollisionExit(Collider2D col)
    {
    }

    public void SlideCollision(Collider2D col)
    {
        m_PlayerControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);

        m_PlayerControl.ChangeState(new SlideState(m_PlayerControl, col));
    }

    public void SlideCollisionExit(Collider2D col)
    {
        m_PlayerControl.gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);

        m_PlayerControl.ChangeState(new AirState(m_PlayerControl));
    }
}
