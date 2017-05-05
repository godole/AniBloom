using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour,
    IObstacle{

    BoxCollider2D m_LineCollider;
    RectTransform m_RopeLineTransform;
    AudioSource m_Effect;
    bool m_IsJudged = false;
    double m_LineAngle;

    // Use this for initialization
    void Awake () {
        m_RopeLineTransform = transform.FindChild("RopeLine").gameObject.GetComponent<RectTransform>();
        m_LineCollider = m_RopeLineTransform.GetComponent<BoxCollider2D>();
        m_LineCollider.size.Set(500, 30);
        m_LineCollider.offset.Set(500 / 2, 0);
        m_Effect = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public BoxCollider2D getCollider()
    {
        return m_LineCollider;
    }

    public Judge JumpJudge(PlayerControl pc)
    {
        return Judge.e_None;
    }

    public Judge TriggerJudge(PlayerControl pc)
    {
        if(!m_IsJudged)
        {
            m_Effect.Play();
            m_IsJudged = true;
        }
        return Judge.e_Miss;
    }

    public void JumpEndJudge(PlayerControl pc)
    {

    }

    public bool IsJudged
    {
        get { return m_IsJudged; }
    }

    public double Angle
    {
        get { return m_LineAngle; }
        set
        {
            m_LineAngle = value;

            m_RopeLineTransform.localRotation = Quaternion.Euler(0, 0, (float)value);
        }
    }

    public int Length
    {
        get { return (int)m_RopeLineTransform.rect.width; }
        set
        {
            m_RopeLineTransform.sizeDelta = new Vector2(value, 30);
            m_LineCollider.size = new Vector2(value, 30);
            m_LineCollider.offset = new Vector2(value / 2, 0);
        }
    }
}
