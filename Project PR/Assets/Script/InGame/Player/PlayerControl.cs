using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public interface IHit
{
    void PlayerHit();
}

public class PlayerControl : MonoBehaviour {

    Rigidbody2D m_RigidBody;
    BoxCollider2D _Collider;

    float m_MaxSpeed;
    [SerializeField]
    float m_JumpForce;

    [SerializeField]
    float m_GravityScale = 90f;
    float m_GravityValue = 0.0f;

    IState m_State;

    public int JumpCount { get; set; }

    public AudioSource m_JumpSound;

    public Animator _Animator { get; set; }

    public int CollisionCount { get; set; }

    public enum PlayerAnimation
    {
        Fail = 0,
        Run,
        Jump,
        Slide,
        Rope,
        Roll,
        Wall,
        Fever,
        DoubleJump
    }

    // Use this for initialization
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        _Collider = GetComponent<BoxCollider2D>();
        m_JumpSound = GetComponent<AudioSource>();
        _Animator = GetComponent<Animator>();
        m_State = new AirState(this);
        MoveVector = new Vector2(m_MaxSpeed, 0.0f);
        JumpCount = 1;
        CollisionCount = 0;
    }

    public void setMoveSpeed(float speed)
    { 
        m_MaxSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        m_State.StateUpdate();
    }

    public void JumpEnterJudge()
    {
        m_State.JumpEnterJudge();
    }

    public void Jump(bool isPlayJumpSound)
    {
        if (JumpCount <= 0)
            return;

        MoveVector += new Vector2(0, JumpForce);
        GravityValue = JumpForce;
        ChangeState(new AirState(this));
        CollisionCount = 0;
        JumpCount--;
    }

    public void JumpReverse(bool isPlayJumpSound)
    {
        if (JumpCount <= 0)
            return;

        if (isPlayJumpSound)
            m_JumpSound.Play();

        MoveVector += new Vector2(0, -JumpForce);
        GravityValue = -JumpForce;
        ChangeState(new AirState(this));
    }

    public void JumpJudge()
    {
        m_State.Jump();
    }

    public void JumpEndJudge()
    {
    }

    public void SlideEnd()
    {
        m_State.SlideEnd();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "DeadTrigger")
        {
            Hit();
        }

        else
        {
            m_State.OnTriggerEnter2D(_Collider, col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        m_State.OnTriggerExit2D(_Collider, col);
    }

    public void StepGround(IStepable stepable)
    {
        GravityValue = 0;
        RectTransform pt = gameObject.transform as RectTransform;
        
        Vector2 stepPosition = stepable.CalcStepPoint(pt as RectTransform);

        pt.position = stepPosition;
        MoveVector = stepable.CalcMoveVector(pt, MaxSpeed);
    }

    public Vector2 getVelocity()
    {
        if (m_RigidBody == null)
            return new Vector2(0, 0);
        else
            return MoveVector;
    }

    public void Hit()
    {
        m_State.Hit();
    }

    public void ChangeState(IState state)
    {
        if(m_State.GetType() != state.GetType())
            m_State = state;
    }

    public Vector2 MoveVector
    {
        get { return m_RigidBody.velocity; }
        set
        {
            m_RigidBody.velocity = value;
        }
    }

    public float MaxSpeed
    {
        get { return m_MaxSpeed; }
    }

    public float GravityValue
    {
        get { return m_GravityValue; }
        set { m_GravityValue = value; }
    }

    public float GravityScale
    {
        get { return m_GravityScale; }
        set { m_GravityScale = value; }
    }

    public float JumpForce
    {
        get { return m_JumpForce; }
        set { m_JumpForce = value; }
    }
}
