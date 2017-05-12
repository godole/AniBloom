using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour
{
    bool m_IsJudged = false;
    RectTransform m_Transform;
    BoxCollider2D m_Collider2D;

    // Use this for initialization
    void Awake()
    {
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_Transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsJudged
    {
        get { return m_IsJudged; }
        set { m_IsJudged = value; }
    }
}
