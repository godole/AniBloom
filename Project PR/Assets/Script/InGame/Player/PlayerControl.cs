using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public interface IHit
{
    void PlayerHit();
}

public class PlayerControl : MonoBehaviour {
    [SerializeField]
    List<IHit> m_Listeners = new List<IHit>();
    [SerializeField]
    ObstacleManager _ObstacleManager;

    Rigidbody2D m_RigidBody;
    BoxCollider2D _Collider;

    float m_MaxSpeed;
    [SerializeField]
    float m_JumpForce;

    [SerializeField]
    float m_GravityScale = 90f;
    float m_GravityValue = 0.0f;

    IState m_State;
    UILabel _JudgeText;
    UILabel _Combo;

    public int JumpCount { get; set; }

    int _ComboCount = 0;

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
        _JudgeText = GameObject.Find("JudgeText").GetComponent<UILabel>();
        _Combo = GameObject.Find("Combo").GetComponent<UILabel>();
        _ObstacleManager = GameObject.Find("Obstacle Manager").GetComponent<ObstacleManager>();
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
        _Combo.text = _ComboCount.ToString();
        _JudgeText.text = CollisionCount.ToString();
        m_State.StateUpdate();
    }

    public void Jump(bool isPlayJumpSound)
    {
        if (JumpCount <= 0)
            return;

        if(isPlayJumpSound)
            m_JumpSound.Play();

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
        bool bIsJudged = false;

        if (!bIsJudged)
        {
            _JudgeText.text = string.Empty;
            m_State.Jump();
        }
    }

    public void JumpEndJudge()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "DeadTrigger")
        {
            SceneManager.LoadScene("InGame");
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

    public void GroundCollisionEnter(Collider2D col)
    {
        CollisionCount++;
        JumpCount = 1;
        ChangeState(new RunningState(this, col));
    }

    public void CollisionExit()
    {
        CollisionCount--;
        if (CollisionCount <= 0)
        {
            JumpCount = 0;
            ChangeState(new AirState(this));
        }
    }

    public void SlideCollisionEnter(Collider2D col)
    {
        CollisionCount++;
        JumpCount = 1;
        ChangeState(new SlideState(this, col));
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
        Notify();
        SceneManager.LoadScene("InGame");
    }

    public void Reset()
    {
    }

    public void ChangeState(IState state)
    {
        if(m_State.GetType() != state.GetType())
            m_State = state;
    }

    public void AddListener(IHit hit)
    {
        m_Listeners.Add(hit);
    }

    public void Notify()
    {
        foreach (IHit obj in m_Listeners)
            obj.PlayerHit();
    }

    public void DeadFromSpring()
    {
        SceneManager.LoadScene("InGame");
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
