using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class AirState : IState {

    PlayerControl m_PlayerControl;

    //cache
    GameObject[] fevers;

    public AirState(PlayerControl pc)
    {
        m_PlayerControl = pc;
        m_PlayerControl._Animator.SetInteger("State", (int)PlayerControl.PlayerAnimation.Jump);
        fevers = GameObject.FindGameObjectsWithTag("Fever");
    }

    public void StateUpdate()
    {
        m_PlayerControl.MoveVector = new Vector2(m_PlayerControl.MoveVector.x, m_PlayerControl.GravityValue);
        m_PlayerControl.GravityValue -= m_PlayerControl.GravityScale * Time.deltaTime;
        m_PlayerControl._Animator.SetFloat("JumpValue", m_PlayerControl.GravityValue);

        if (m_PlayerControl.gameObject.transform.localPosition.y > 1200)
            m_PlayerControl.gameObject.transform.localPosition = new Vector3(m_PlayerControl.gameObject.transform.localPosition.x, 600, m_PlayerControl.gameObject.transform.localPosition.z);

        
        for(int i = 0; i < fevers.Length; i++)
        {
            var feverTransform = fevers[i].GetComponent<RectTransform>();
            if(Vector2.Distance(feverTransform.position, m_PlayerControl.gameObject.transform.position) < feverTransform.sizeDelta.x)
            {
                m_PlayerControl.ChangeState(new FeverState(m_PlayerControl));
            }
        }
    }

    public void Jump()
    {
    }

    public void OnTriggerEnter2D(Collider2D col, Collider2D target)
    {
        if(col.transform.tag == "Player")
        {
            if (target.transform.tag == "Obstacle")
                m_PlayerControl.Hit();

            else if (target.transform.tag == "DoubleJump")
                m_PlayerControl.ChangeState(new DoubleJumpState(m_PlayerControl));

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

    public void SlideEnd()
    {
    }

    public void Hit()
    {
        SceneManager.LoadScene("Test");
    }

    public void JumpEnterJudge()
    {
    }
}
