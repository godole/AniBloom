using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour{
    [SerializeField]
    Sprite m_SpringSprite;

    GameObject[] m_SpringArr;
    PlayerControl m_PlayerControl;
    bool m_bIsChecked = false;
    int m_Index = 0;
    bool m_bIsStart = false;

    public bool IsUpStart { get; set; }
    public int ScaleCount { get; set; }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(m_bIsStart)
        {
            if(m_SpringArr[m_Index + 1].transform.position.x < m_PlayerControl.gameObject.transform.position.x)
            {
                m_Index++;
                if (m_Index + 2 > m_SpringArr.Length)
                {
                    m_bIsChecked = true;
                    m_bIsStart = false;
                    float jp = 0;
                    if(m_Index % 2 == 1 && !IsUpStart)
                        jp =  m_PlayerControl.JumpForce;
                    m_PlayerControl.MoveVector = new Vector2(m_PlayerControl.MaxSpeed, jp);
                    m_PlayerControl.GravityValue = jp;
                    m_PlayerControl.ChangeState(new AirState(m_PlayerControl));
                    return;
                }
                
                Vector2 deltaPos = m_PlayerControl.gameObject.transform.position - m_SpringArr[m_Index + 1].transform.position;
                float angle = Mathf.Atan2(deltaPos.y, deltaPos.x);
                float length = Mathf.Sqrt(new Vector2(m_PlayerControl.MaxSpeed, 0.0f).SqrMagnitude()) / Mathf.Cos(angle);

                m_PlayerControl.MoveVector = deltaPos.normalized * length;
            }
        }
    }

    public void OnValidate()
    {
        Length = _Length;
    }

    [SerializeField]
    private int _Length;

    public int Length
    {
        get { return m_SpringArr.Length; }
        set
        {
            _Length = value;
            m_SpringArr = new GameObject[value];
            for (int i = 0; i < value; i++)
            {
                var springobj = new GameObject();
                var springimg = springobj.AddComponent<UnityEngine.UI.Image>();
                springimg.sprite = m_SpringSprite;

                springobj.transform.SetParent(gameObject.transform);
                springobj.transform.localScale = new Vector3(1, m_SpringSprite.rect.height / m_SpringSprite.rect.width, 1);

                /*double posx = (DeltaPos.x / 4 * ScaleCount * i);
                double posy = (i % 2 == (IsUpStart ? 0 : 1) ? 0 : DeltaPos.y * 2) / 4 * ScaleCount;*/
                /*double posx = (100 / 4 * 1 * i);
                double posy = (i % 2 == (IsUpStart ? 0 : 1) ? 0 : 100 * 2) / 4 * 1;
                springobj.transform.localPosition = new Vector2((float)posx, (float)posy);*/

                m_SpringArr[i] = springobj;
            }
        }
    }

    public Vector2 DeltaPos { get; set; }

    public void JumpEndJudge(PlayerControl pc)
    {
        if(m_bIsStart)
        {
            pc.Hit();
        }
    }

    public bool IsJudged
    {
        get { return m_bIsChecked; }
    }
}
